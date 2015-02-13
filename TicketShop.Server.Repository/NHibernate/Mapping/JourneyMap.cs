using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Server.Repository.NHibernate.Mapping
{
    public class JourneyMap : ClassMap<Journey>
    {
        public JourneyMap()
        {
            Id(x => x.Id);
            Map(x => x.EstimatedFinishDateTime);
            Map(x => x.StartDateTime).Not.Nullable();
            References(x => x.FinishAddress).Not.Nullable();
            References(x => x.StartAddress).Not.Nullable();
            References(x => x.Vehicle).Not.Nullable();
        }
    }
}
