using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Messages.Executer;
using TicketShop.Server.MessageHandler;

namespace TicketShop.Server.WcfService.Core
{
    public class DefaultMessageExecuter : IMessageExecuter
    {
        private readonly IMessageHandlerSelector messageHandlerSelector;
        public DefaultMessageExecuter(IMessageHandlerSelector messageHandlerSelector)
        {
            this.messageHandlerSelector = messageHandlerSelector;
        }
        public TResponseMessage Execute<TRequestMessage, TResponseMessage>(TRequestMessage requestMessage)
            where TRequestMessage : class
            where TResponseMessage : class
        {
            IGenericMessageHandler<TRequestMessage, TResponseMessage> messageHandler = this.messageHandlerSelector.Select<TRequestMessage, TResponseMessage>(requestMessage);
            return messageHandler.Handle(requestMessage);
        }
    }
}
