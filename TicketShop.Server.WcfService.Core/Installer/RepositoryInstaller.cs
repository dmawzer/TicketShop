using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Server.Repository.Core;
using TicketShop.Server.Repository.NHibernate;

namespace TicketShop.Server.WcfService.Core.Installer
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For(typeof(IGenericRepository<>))
                .ImplementedBy(typeof(GenericRepository<>))
                .Named("GenericRepository")
                );
        }
    }
}
