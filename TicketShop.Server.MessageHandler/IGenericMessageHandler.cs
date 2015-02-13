using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Messages.Request;
using TicketShop.Core.Messages.Response;

namespace TicketShop.Server.MessageHandler
{
    public interface IGenericMessageHandler<in TRequest, out TResponse>
    {
        TResponse Handle(TRequest request);
    }
}
