using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Server.Repository.NHibernate.Mapping
{
    public class PassengerMap : ClassMap<Passenger>
    {
        public PassengerMap()
        {
            Id(x => x.Id);
            Map(x => x.Gender).Not.Nullable();
            Map(x => x.IdentityNumber).Not.Nullable();
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Surname).Not.Nullable();
        }
    }
}
