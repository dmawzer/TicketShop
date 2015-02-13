using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Server.Repository.NHibernate.Mapping
{
    public class VehicleMap : ClassMap<Vehicle>
    {
        public VehicleMap()
        {
            Id(x => x.Id);
            Map(x => x.NumberPlate).Not.Nullable();
            Map(x => x.ChairCount).Not.Nullable();
            HasManyToMany(x => x.DriverList).AsList();
        }
    }
}
