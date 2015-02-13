using Infragistics.Windows.DockManager;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicketShop.Client.Wpf.Core;
using Countryy = TicketShop.Core.Domain.Model.Country;

namespace TicketShop.Client.Wpf.Module.Country
{
    /// <summary>
    /// Interaction logic for CountryEdit.xaml
    /// </summary>
    public partial class CountryEdit : EditModule
    {
        public CountryEdit()
        {
            InitializeComponent();
        }

        protected override ContentPane CreateContentPane(string header)
        {
            ContentPane contentPane = new ContentPane
            {
                Header = string.IsNullOrEmpty(header) ? "New Country" : header,
                Content = this
            };
            return contentPane;
        }
    }
}
