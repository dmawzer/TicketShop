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
using Cityy = TicketShop.Core.Domain.Model.City;

namespace TicketShop.Client.Wpf.Module.City
{
    /// <summary>
    /// Interaction logic for CityEdit.xaml
    /// </summary>
    public partial class CityEdit : EditModule
    {
        public CityEdit()
        {
            InitializeComponent();
        }
    }
}
