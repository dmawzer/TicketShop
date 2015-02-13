using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using TicketShop.Core.Messages.Executer;
using TicketShop.Server.MessageHandler;
using TicketShop.Server.WcfService.Core;

namespace TicketShop.Server.WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TicketShopWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TicketShopWcfService.svc or TicketShopWcfService.svc.cs at the Solution Explorer and start debugging.
    public class TicketShopWcfService : IMessageExecuterService
    {
        private readonly IMessageExecuter messageExecuter;
        private IWindsorContainer container;

        public TicketShopWcfService()
        {
            BuildContainer();
            this.messageExecuter = container.Resolve<IMessageExecuter>("MessageExecuter");
        }
        public Message Execute(Message message)
        {
            return messageExecuter.Execute<Message, Message>(message);
        }

        private void BuildContainer()
        {
            BootStrapper bootStrapper = new BootStrapper();
            container = bootStrapper.ConfigureContainer();
        }
    }
}
