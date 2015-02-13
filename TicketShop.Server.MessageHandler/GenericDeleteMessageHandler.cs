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
    public class GenericDeleteMessageHandler<TModel> : IGenericMessageHandler<GenericDeleteRequest<TModel>, GenericResponse<TModel>>
    {
        private readonly IGenericService<TModel> genericService;

        public GenericDeleteMessageHandler(IGenericService<TModel> genericService)
        {
            this.genericService = genericService;
        }

        public GenericResponse<TModel> Handle(GenericDeleteRequest<TModel> request)
        {
            genericService.Delete(request.Model);
            var response = new GenericResponse<TModel> { Model = request.Model };
            return response;
        }
    }
}
