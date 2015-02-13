using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Client.Wpf
{
    public class IoCContainerManager
    {
        private static IoCContainerManager instance;
        private static object lockObject = new object();
        private readonly IWindsorContainer windsorContainer;

        private IoCContainerManager()
        {
            Bootstrapper bootstrapper = new Bootstrapper();
            windsorContainer = bootstrapper.ConfigureContainer();
        }

        public static IoCContainerManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance = new IoCContainerManager();
                    }
                }
                return instance;
            }
        }

        public IWindsorContainer WindsorContainer
        {
            get { return windsorContainer; }
        }
    }
}
