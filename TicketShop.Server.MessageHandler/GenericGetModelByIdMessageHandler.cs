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
    public class GenericGetModelByIdMessageHandler<TModel> : IGenericMessageHandler<GetModelByIdRequest, GenericResponse<TModel>>
    {
        private readonly IGenericService<TModel> genericService;

        public GenericGetModelByIdMessageHandler(IGenericService<TModel> genericService)
        {
            this.genericService = genericService;
        }

        public GenericResponse<TModel> Handle(GetModelByIdRequest request)
        {
            TModel model = genericService.GetBy(request.Model);
            var response = new GenericResponse<TModel> { Model = model };
            return response;
        }
    }
}
