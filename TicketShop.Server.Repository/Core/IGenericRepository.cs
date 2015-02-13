using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Server.Repository.Core
{
    public interface IGenericRepository<TModel>
    {
        TModel GetBy(int id);
        IList<TModel> GetAll();
        void SaveOrUpdate(TModel model);
        void Delete(TModel model);
    }
}
