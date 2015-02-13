using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Server.MessageHandler;

namespace TicketShop.Server.WcfService.Core
{
    public class DefaultMessageHandlerSelector : IMessageHandlerSelector
    {
        private readonly IWindsorContainer windsorContainer;

        public DefaultMessageHandlerSelector(IWindsorContainer windsorContainer)
        {
            this.windsorContainer = windsorContainer;
        }

        public IGenericMessageHandler<TRequestMessage, TResponseMessage> Select<TRequestMessage, TResponseMessage>(TRequestMessage requestMessage)
        {
            string fullName = requestMessage.GetType().FullName;
            IGenericMessageHandler<TRequestMessage, TResponseMessage> messageHandler = this.windsorContainer.Resolve<IGenericMessageHandler<TRequestMessage, TResponseMessage>>();
            return messageHandler;
        }
    }
}
