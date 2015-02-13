using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Client.Service.Core;
using TicketShop.Core.Messages.Request;
using TicketShop.Core.Messages.Response;

namespace TicketShop.Client.Service.Implementation
{
    public class GenericDataService<TModel> : IGenericDataService<TModel>
    {
        private readonly IWcfMessageExecuter wcfMessageExecuter;

        public GenericDataService(IWcfMessageExecuter wcfMessageExecuter)
        {
            this.wcfMessageExecuter = wcfMessageExecuter;
        }

        public TModel GetBy(int id)
        {
            GetModelByIdRequest request = new GetModelByIdRequest() { Model = id };
            GenericResponse<TModel> response = wcfMessageExecuter.Execute<GetModelByIdRequest, GenericResponse<TModel>>(request);
            return response.Model;
        }

        public IList<TModel> GetAll()
        {
            GenericListRequest<TModel> request = new GenericListRequest<TModel>();
            GenericResponse<IList<TModel>> response = wcfMessageExecuter.Execute<GenericListRequest<TModel>, GenericResponse<IList<TModel>>>(request);
            return response.Model;
        }

        public void SaveOrUpdate(TModel model)
        {
            GenericSaveRequest<TModel> request = new GenericSaveRequest<TModel>() { Model = model };
            GenericResponse<TModel> response = wcfMessageExecuter.Execute<GenericSaveRequest<TModel>, GenericResponse<TModel>>(request);
        }

        public void Delete(TModel model)
        {
            GenericDeleteRequest<TModel> request = new GenericDeleteRequest<TModel>() { Model = model };
            GenericResponse<TModel> response = wcfMessageExecuter.Execute<GenericDeleteRequest<TModel>, GenericResponse<TModel>>(request);
        }
    }
}
