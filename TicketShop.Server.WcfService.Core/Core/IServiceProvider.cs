using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Server.WcfService.Core.Core
{
    public interface IServiceProvider
    {
        T GetService<T>() where T : class;
        object GetService(Type type);

    }
}
