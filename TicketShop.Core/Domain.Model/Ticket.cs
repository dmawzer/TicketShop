using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Domain.Model
{
    public class Ticket : AbstractDomainModel
    {
        public virtual int Id { get; set; }

        public virtual Journey Journey { get; set; }

        public virtual Passenger Passenger { get; set; }

        public virtual int ChairNumber { get; set; }
    }
}
