using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Core.Domain.Model
{
    public class Journey
    {
        public virtual int Id { get; set; }

        public virtual Vehicle Vehicle { get; set; }

        public virtual JourneyAddress StartAddress { get; set; }

        public virtual JourneyAddress FinishAddress { get; set; }

        public virtual DateTime StartDateTime { get; set; }

        public virtual DateTime EstimatedFinishDateTime { get; set; }
    }
}
