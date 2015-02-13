using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Client.Wpf.Core
{
    public interface IModule
    {
        void Show(ViewModelBase viewModel);
        void Show(string header, ViewModelBase viewModel);
    }
}
