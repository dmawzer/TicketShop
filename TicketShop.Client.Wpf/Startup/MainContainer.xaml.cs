using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TicketShop.Client.Wpf.Core;

namespace TicketShop.Client.Wpf.Startup
{
    /// <summary>
    /// Interaction logic for MainModule.xaml
    /// </summary>
    public partial class MainContainer : Window, IContainer
    {
        public MainContainer()
        {
            InitializeComponent();
            ModuleListManager.Instance.ContentPaneAdded += Instance_ContentPaneAdded;
        }

        private void Instance_ContentPaneAdded(object sender, Infragistics.Windows.DockManager.ContentPane e)
        {
            foreach (var item in controlMainTabGroupPane.Items)
            {
                 var i=item as Infragistics.Windows.DockManager.ContentPane;
                if (i != null && i.Header == e.Header)
                {
                    i.Activate();
                    return;
                }
            }

            controlMainTabGroupPane.Items.Add(e);
        }

        public void Show(ViewModelBase viewModel)
        {
            DataContext = viewModel;
            this.Show();
        }
    }
}
