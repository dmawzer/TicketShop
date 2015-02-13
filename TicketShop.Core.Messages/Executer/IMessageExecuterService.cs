using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Messages.Executer
{
    [ServiceContract]
    public interface IMessageExecuterService
    {
        [OperationContract(Action = "*", ReplyAction = "*")]
        Message Execute(Message message);
    }
}
