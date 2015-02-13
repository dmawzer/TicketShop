using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Messages.Executer;

namespace TicketShop.Server.WcfService.Core
{
    public class MessageExecuter : IMessageExecuter
    {
        private readonly IMessageExecuter messageExecuter;
        private readonly Type messageExecuterType;
        private readonly MethodInfo messageExecuterMethodInfo;
        private Type wcfMessageType;
        private MethodInfo wcfMessageMethodInfo;

        public MessageExecuter(IMessageExecuter messageExecuter)
		{
			this.messageExecuter = messageExecuter;
			this.messageExecuterType = messageExecuter.GetType();
			this.messageExecuterMethodInfo = this.messageExecuterType.GetMethod("Execute");
		}

        public TResponse Execute<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            Message message = request as Message;
            Type requestMessageType = GetRequestMessageType(message);
            Type responseMessageType = GetResponseMessageType(message);
            object requestMessage = GetRequestMessage(message, requestMessageType);
            object responseMessage = GetResponseMessage(requestMessage, requestMessageType, responseMessageType);
            Message message2 = Message.CreateMessage(MessageVersion.Default, "GetDataResponse", responseMessage);
            return message2 as TResponse;
        }

        private object GetResponseMessage(object requestMessage, Type requestMessageType, Type responseMessageType)
        {
            MethodInfo methodInfo = this.messageExecuterMethodInfo.MakeGenericMethod(new Type[]
			{
				requestMessageType,
				responseMessageType
			});
            return methodInfo.Invoke(this.messageExecuter, new object[]
			{
				requestMessage
			});
        }

        private object GetRequestMessage(Message message, Type requestMessageType)
        {
            if (this.wcfMessageType == null)
            {
                this.wcfMessageType = message.GetType();
                this.wcfMessageMethodInfo = this.wcfMessageType.GetMethod("GetBody", new Type[0]);
            }
            MethodInfo methodInfo = this.wcfMessageMethodInfo.MakeGenericMethod(new Type[]
			{
				requestMessageType
			});
            return methodInfo.Invoke(message, null);
        }

        private Type GetResponseMessageType(Message message)
        {
            string header = message.Headers.GetHeader<string>("ResponseMessageType", "Action");
            return Type.GetType(header);
        }

        private Type GetRequestMessageType(Message message)
        {
            string header = message.Headers.GetHeader<string>("RequestMessageType", "Action");
            return Type.GetType(header);
        }
    }
}
