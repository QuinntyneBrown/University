using System.Net;
using System.Threading.Tasks;
using University.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace University.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CellphoneController
    {
        private readonly IMediator _mediator;

        public CellphoneController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{cellphoneId}", Name = "GetCellphoneByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCellphoneById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCellphoneById.Response>> GetById([FromRoute]GetCellphoneById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Cellphone == null)
            {
                return new NotFoundObjectResult(request.CellphoneId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetCellphonesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCellphones.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCellphones.Response>> Get()
            => await _mediator.Send(new GetCellphones.Request());
        
        [HttpPost(Name = "CreateCellphoneRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCellphone.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCellphone.Response>> Create([FromBody]CreateCellphone.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetCellphonesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCellphonesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCellphonesPage.Response>> Page([FromRoute]GetCellphonesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateCellphoneRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCellphone.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCellphone.Response>> Update([FromBody]UpdateCellphone.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{cellphoneId}", Name = "RemoveCellphoneRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCellphone.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCellphone.Response>> Remove([FromRoute]RemoveCellphone.Request request)
            => await _mediator.Send(request);
        
    }
}
