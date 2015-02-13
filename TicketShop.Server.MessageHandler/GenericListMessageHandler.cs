using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketShop.Core.Messages.Request;
using TicketShop.Core.Messages.Response;
using TicketShop.Server.Service.Core;

namespace TicketShop.Server.MessageHandler
{
    public class GenericListMessageHandler<TModel> : IGenericMessageHandler<GenericListRequest<TModel>, GenericResponse<IList<TModel>>>
    {
        private readonly IGenericService<TModel> genericService;

        public GenericListMessageHandler(IGenericService<TModel> genericService)
        {
            this.genericService = genericService;
        }

        public GenericResponse<IList<TModel>> Handle(GenericListRequest<TModel> request)
        {
            IList<TModel> modelList = genericService.GetAll();
            var response = new GenericResponse<IList<TModel>> { Model = modelList };
            return response;
        }
    }
}
