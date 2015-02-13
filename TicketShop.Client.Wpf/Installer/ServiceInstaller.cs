using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Client.Service.Core;
using TicketShop.Client.Service.Implementation;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Client.Wpf.Installer
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component.For<IWcfMessageExecuter>()
                .ImplementedBy<DefaultWcfMessageExecuter>()
                .Named("DefaultWcfMessageExecuter"),

                Component.For<IGenericDataService<Country>>()
                .ImplementedBy<GenericDataService<Country>>()
                .Named("CountryDataService")
                );
        }
    }
}
