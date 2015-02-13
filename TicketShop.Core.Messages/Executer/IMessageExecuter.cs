using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Messages.Executer
{
    public interface IMessageExecuter
    {
        TResponse Execute<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class;
    }
}
