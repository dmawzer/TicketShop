using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Client.Wpf.Core;
using TicketShop.Client.Wpf.Module.Country;
using TicketShop.Client.Wpf.Startup;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Client.Wpf.Installer
{
    public class ModuleInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component.For<IContainer>()
                .ImplementedBy<MainContainer>()
                .Named("MainContainer"),

                Component.For<IModule>()
                .ImplementedBy<CountryList>()
                .Named("CountryListModule")
                .LifeStyle.Transient,

                Component.For<IModule>()
                .ImplementedBy<CountryEdit>()
                .Named("CountryEditModule")
                .LifeStyle.Transient
                );
        }
    }
}
