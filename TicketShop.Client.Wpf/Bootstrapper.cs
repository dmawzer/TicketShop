using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Client.Wpf.Installer;

namespace TicketShop.Client.Wpf
{
    public class Bootstrapper : IDisposable
    {
        private IWindsorContainer container;

        public IWindsorContainer ConfigureContainer()
        {
            if (container == null)
            {
                container = new WindsorContainer();
            }

            ModuleInstaller moduleInstaller = new ModuleInstaller();
            ViewModelInstaller viewModelInstaller = new ViewModelInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();
            container.Install(serviceInstaller, moduleInstaller, viewModelInstaller);

            return container;
        }

        public void Dispose()
        {
            if (container != null)
            {
                container.Dispose();
                container = null;
            }
        }
    }
}
