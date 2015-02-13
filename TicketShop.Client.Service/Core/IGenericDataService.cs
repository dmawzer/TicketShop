using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketShop.Client.Service.Core
{
    public interface IGenericDataService<TModel>
    {
        TModel GetBy(int id);
        IList<TModel> GetAll();
        void SaveOrUpdate(TModel model);
        void Delete(TModel model);
    }
}
