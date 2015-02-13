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
    public class ViewModelInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component.For<ViewModelBase>()
                .ImplementedBy<MainContainerViewModel>()
                .Named("MainContainerViewModel")
                .DependsOn(Dependency.OnComponent("mainContainer", "MainContainer")),

                Component.For<ViewModelBase>()
                .ImplementedBy<CountryListViewModel>()
                .LifeStyle.Transient
                .Named("CountryListViewModel")
                .DependsOn(Dependency.OnComponent("countryListModule", "CountryListModule")),

                Component.For<ViewModelBase>()
                .ImplementedBy<CountryEditViewModel>()
                .LifeStyle.Transient
                .Named("CountryEditViewModel")
                .DependsOn(Dependency.OnComponent("countryEditModule", "CountryEditModule"))
                );
        }
    }
}
