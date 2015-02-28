using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Logical;

namespace TicketShop.Core.Domain.Model
{
    public class Passenger : AbstractDomainModel
    {
        public virtual int Id { get; set; }

        public virtual string IdentityNumber { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
