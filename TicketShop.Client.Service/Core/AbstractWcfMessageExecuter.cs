using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Client.Service.Core
{
    public abstract class AbstractWcfMessageExecuter : IWcfMessageExecuter
    {
        public TResponse Execute<TRequest, TResponse>(TRequest request)
        {
            Message wcfRequestMessage = ConvertToWcfMessage<TRequest, TResponse>(request);
            TResponse responseMessage = ExecuteInternal<TResponse>(wcfRequestMessage);

            return responseMessage;
        }

        protected abstract TResponse ExecuteInternal<TResponse>(Message wcfRequestMessage);

        protected virtual Message ConvertToWcfMessage<TRequestMessage, TResponseMessage>(TRequestMessage requestMessage)
        {
            string requestMessageType = requestMessage.GetType().AssemblyQualifiedName;
            string responseMessageType = typeof(TResponseMessage).AssemblyQualifiedName;

            Message message = Message.CreateMessage(MessageVersion.Default, "*", requestMessage);
            MessageHeader messageHeader1 = MessageHeader.CreateHeader("RequestMessageType", "Action", requestMessageType);
            message.Headers.Add(messageHeader1);

            MessageHeader messageHeader2 = MessageHeader.CreateHeader("ResponseMessageType", "Action", responseMessageType);
            message.Headers.Add(messageHeader2);
            return message;
        }

        protected virtual Binding BuildBinding()
        {
            WSHttpBinding binding = new WSHttpBinding();
            binding.CloseTimeout = new TimeSpan(0, 1, 5, 0);
            binding.OpenTimeout = new TimeSpan(0, 1, 5, 0);
            binding.SendTimeout = new TimeSpan(0, 1, 5, 0);
            binding.ReceiveTimeout = new TimeSpan(0, 1, 5, 0);

            binding.MaxReceivedMessageSize = 10000000;
            binding.MaxBufferPoolSize = 10000000;

            binding.ReaderQuotas.MaxDepth = 32;
            binding.ReaderQuotas.MaxStringContentLength = 1000000000;
            binding.ReaderQuotas.MaxArrayLength = 16384;

            binding.ReaderQuotas.MaxBytesPerRead = 4096;
            binding.ReaderQuotas.MaxNameTableCharCount = 16384;

            binding.Security.Mode = SecurityMode.None;
            return binding;
        }

        protected virtual void HandleFault(Message wcfResponseMessage)
        {
            MessageFault messageFault = MessageFault.CreateFault(wcfResponseMessage, int.MaxValue);
            if (!messageFault.HasDetail)
            {
                throw new Exception("TicketShop Wcf service has exception but doesnt has exception detail.");
            }
            ExceptionDetail exceptionDetail = messageFault.GetDetail<ExceptionDetail>();
            ExceptionDetail innerException = exceptionDetail;
            while (innerException.InnerException != null)
            {
                innerException = innerException.InnerException;
            }
            string message = string.Format("TicketShop Wcf Service Exception\nType : {0}\nMessage : {1}\nStack Trace : {2}", innerException.Type, innerException.Message, innerException.StackTrace);
            throw new Exception(message);
        }
    }
}
