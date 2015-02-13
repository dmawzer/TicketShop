using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Server.MessageHandler;

namespace TicketShop.Server.WcfService.Core
{
    public interface IMessageHandlerSelector
    {
        IGenericMessageHandler<TRequestMessage, TResponseMessage> Select<TRequestMessage, TResponseMessage>(TRequestMessage requestMessage);
    }
}
