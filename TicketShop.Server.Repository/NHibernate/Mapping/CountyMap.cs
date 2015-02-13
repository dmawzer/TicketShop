using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Server.Repository.NHibernate.Mapping
{
    public class CountyMap : ClassMap<County>
    {
        public CountyMap()
        {
            Id(x => x.Id);
            Map(x => x.Name).Not.Nullable();
            References(x => x.City).Not.Nullable();
        }
    }
}
