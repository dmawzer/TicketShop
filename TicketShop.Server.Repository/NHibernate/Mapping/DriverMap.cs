using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Server.Repository.NHibernate.Mapping
{
    public class DriverMap : ClassMap<Driver>
    {
        public DriverMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Surname).Not.Nullable();
            Map(x => x.IdentityNumber);
            Map(x => x.GsmNumber).Not.Nullable();
            Map(x => x.Email);
            Map(x => x.Address);
        }
    }
}
