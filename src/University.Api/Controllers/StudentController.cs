using System.Net;
using System.Threading.Tasks;
using University.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace University.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{studentId}", Name = "GetStudentByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStudentById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStudentById.Response>> GetById([FromRoute]GetStudentById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Student == null)
            {
                return new NotFoundObjectResult(request.StudentId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetStudentsRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStudents.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStudents.Response>> Get()
            => await _mediator.Send(new GetStudents.Request());
        
        [HttpPost(Name = "CreateStudentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateStudent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateStudent.Response>> Create([FromBody]CreateStudent.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetStudentsPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetStudentsPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetStudentsPage.Response>> Page([FromRoute]GetStudentsPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateStudentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateStudent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateStudent.Response>> Update([FromBody]UpdateStudent.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{studentId}", Name = "RemoveStudentRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveStudent.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveStudent.Response>> Remove([FromRoute]RemoveStudent.Request request)
            => await _mediator.Send(request);
        
    }
}
