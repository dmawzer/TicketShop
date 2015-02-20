using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Domain.Model
{
    public class Vehicle : IDomainModel
    {
        public virtual int Id { get; set; }

        public virtual string NumberPlate { get; set; }

        public virtual IList<Driver> DriverList { get; set; }

        public virtual int ChairCount { get; set; }
    }
}
