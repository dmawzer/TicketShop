using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Server.Repository.Core
{
    public interface IGenericRepository<TModel> where TModel :  AbstractDomainModel
    {
        TModel GetBy(int id);
        IList<TModel> GetAll();
        void SaveOrUpdate(TModel model);
        void Delete(TModel model);
    }
}
