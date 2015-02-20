using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Domain.Model
{
    public class County : IDomainModel
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual City City { get; set; }
    }
}
