using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Messages.Response
{
    public class GenericResponse<TModel>
    {
        public TModel Model { get; set; }
    }
}
