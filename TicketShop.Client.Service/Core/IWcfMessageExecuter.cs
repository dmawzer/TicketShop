using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Client.Service.Core
{
    public interface IWcfMessageExecuter
    {
        TResponse Execute<TRequest, TResponse>(TRequest request);
    }
}
