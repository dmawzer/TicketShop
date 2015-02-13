using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Domain.Model
{
    [Serializable]
    public class City
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Country Country { get; set; }
    }
}
