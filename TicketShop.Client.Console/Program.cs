using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Client.Service;
using TicketShop.Client.Service.Core;
using TicketShop.Client.Service.Implementation;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IWcfMessageExecuter wcf = new DefaultWcfMessageExecuter();
            IGenericDataService<Ticket> dataService = new GenericDataService<Ticket>(wcf);
            var country = dataService.GetAll();

        }
    }
}
