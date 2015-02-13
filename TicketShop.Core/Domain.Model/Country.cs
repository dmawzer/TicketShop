using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Domain.Model
{
    [Serializable]
    public class Country
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Code { get; set; }
    }
}
