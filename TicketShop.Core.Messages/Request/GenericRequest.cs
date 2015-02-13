using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Messages.Request
{
    public class GenericRequest<TModel>
    {
        public TModel Model { get; set; }
    }
}
