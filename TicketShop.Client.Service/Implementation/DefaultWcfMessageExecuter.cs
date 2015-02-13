using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Client.Service.Core;
using TicketShop.Core.Messages.Executer;

namespace TicketShop.Client.Service.Implementation
{
    public class DefaultWcfMessageExecuter : AbstractWcfMessageExecuter
    {
        private readonly ChannelFactory<IMessageExecuterService> channelFactory;

        public DefaultWcfMessageExecuter()
        {
            channelFactory = new ChannelFactory<IMessageExecuterService>("IMessageExecuterServiceEndpointConfig");
        }

        protected override TResponse ExecuteInternal<TResponse>(Message wcfMessage)
        {
            IMessageExecuterService messageExecuterService = channelFactory.CreateChannel();
            IClientChannel clientChannel = (IClientChannel)messageExecuterService;

            try
            {
                clientChannel.Open();
                Message wcfResponse = messageExecuterService.Execute(wcfMessage);
                clientChannel.Close();

                if (wcfResponse.IsFault)
                {
                    HandleFault(wcfResponse);
                }

                TResponse response = wcfResponse.GetBody<TResponse>();
                return response;
            }
            catch (Exception)
            {
                clientChannel.Abort();
                throw;
            }
        }
    }
}
