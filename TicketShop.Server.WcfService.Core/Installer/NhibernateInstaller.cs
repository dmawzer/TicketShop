using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Server.Repository.NHibernate.Mapping;

namespace TicketShop.Server.WcfService.Core.Installer
{
    public class NhibernateInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            ISessionFactory sessionFactory = CreateSessionFactory();

            container.Register(
                Component.For<ISessionFactory>()
                .Instance(sessionFactory)
                .Named("sessionFactory")
                );
        }

        private ISessionFactory CreateSessionFactory()
        {
            string connectionString = @"Server=BTUGDENIZNB; Database=TicketShop; Trusted_Connection=True;";

            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<CityMap>())
                //.ExposeConfiguration(x => new SchemaExport(x).Create(true, true))
                .BuildSessionFactory();
        }
    }
}
