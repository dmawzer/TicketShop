using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Domain.Model
{
    public class JourneyAddress : IDomainModel
    {
        public virtual int Id { get; set; }

        public virtual County County { get; set; }

        public virtual string Address { get; set; }
    }
}
