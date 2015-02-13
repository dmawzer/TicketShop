using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Server.Repository.NHibernate.Mapping
{
    public class JourneyAddressMap : ClassMap<JourneyAddress>
    {
        public JourneyAddressMap()
        {
            Id(x => x.Id);
            Map(x => x.Address).Not.Nullable();
            References(x => x.County).Not.Nullable();
        }
    }
}
