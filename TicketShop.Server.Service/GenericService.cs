using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Server.Repository.Core;
using TicketShop.Server.Service.Core;
using TicketShop.Core.Domain.Model;

namespace TicketShop.Server.Service
{
    public class GenericService<TModel> : IGenericService<TModel> where TModel : class, IDomainModel
    {
        private readonly IGenericRepository<TModel> repository;

        public GenericService(IGenericRepository<TModel> repository)
        {
            this.repository = repository;
        }

        public TModel GetBy(int id)
        {
            TModel model = repository.GetBy(id);
            return model;
        }

        public IList<TModel> GetAll()
        {
            IList<TModel> modelList = repository.GetAll();
            return modelList;
        }

        public void SaveOrUpdate(TModel model)
        {
            repository.SaveOrUpdate(model);
        }

        public void Delete(TModel model)
        {
            repository.Delete(model);
        }
    }
}
