using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TicketShop.Client.Wpf.Core;

namespace TicketShop.Client.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ViewModelBase viewModel = IoCContainerManager.Instance.WindsorContainer.Resolve<ViewModelBase>("MainContainerViewModel");
            viewModel.ShowWindow();
        }
    }
}
