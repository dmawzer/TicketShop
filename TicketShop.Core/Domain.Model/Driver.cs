using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Domain.Model
{
    public class Driver
    {
        public virtual int Id { get; set; }

        public virtual string IdentityNumber { get; set; }

        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual string Address { get; set; }

        public virtual string GsmNumber { get; set; }

        public virtual string Email { get; set; }
    }
}
