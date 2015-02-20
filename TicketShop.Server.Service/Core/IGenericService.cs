using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Server.Service.Core
{
    public interface IGenericService<TModel> where TModel : class, IDomainModel
    {
        TModel GetBy(int id);
        IList<TModel> GetAll();
        void SaveOrUpdate(TModel model);
        void Delete(TModel model);
    }
}
