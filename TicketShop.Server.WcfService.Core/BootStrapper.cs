using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Server.WcfService.Core.Installer;

namespace TicketShop.Server.WcfService.Core
{
    public class BootStrapper : IDisposable
    {
        private IWindsorContainer container;

        public IWindsorContainer ConfigureContainer()
        {
            if (container == null)
            {
                container = new WindsorContainer();
            }
            
            NhibernateInstaller nhibernateInstaller = new NhibernateInstaller();
            RepositoryInstaller repositoryInstaller = new RepositoryInstaller();
            ServiceInstaller serviceInstaller = new ServiceInstaller();
            container.Install(nhibernateInstaller, repositoryInstaller, serviceInstaller);

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
