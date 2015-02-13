using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Server.Repository.NHibernate.Mapping
{
    public class TicketMap : ClassMap<Ticket>
    {
        public TicketMap()
        {
            Id(x => x.Id);
            Map(x => x.ChairNumber).Not.Nullable();
            References(x => x.Passenger).Not.Nullable();
            References(x => x.Journey).Not.Nullable();
        }
    }
}
