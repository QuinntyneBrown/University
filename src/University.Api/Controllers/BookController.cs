using System.Net;
using System.Threading.Tasks;
using University.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace University.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{bookId}", Name = "GetBookByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBookById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBookById.Response>> GetById([FromRoute] GetBookById.Request request)
        {
            var response = await _mediator.Send(request);

            if (response.Book == null)
            {
                return new NotFoundObjectResult(request.BookId);
            }

            return response;
        }

        [HttpGet(Name = "GetBooksRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBooks.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBooks.Response>> Get()
            => await _mediator.Send(new GetBooks.Request());

        [HttpPost(Name = "CreateBookRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateBook.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateBook.Response>> Create([FromBody] CreateBook.Request request)
            => await _mediator.Send(request);

        [HttpGet("page/{pageSize}/{index}", Name = "GetBooksPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetBooksPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetBooksPage.Response>> Page([FromRoute] GetBooksPage.Request request)
            => await _mediator.Send(request);

        [HttpPut(Name = "UpdateBookRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateBook.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateBook.Response>> Update([FromBody] UpdateBook.Request request)
            => await _mediator.Send(request);

        [HttpDelete("{bookId}", Name = "RemoveBookRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveBook.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveBook.Response>> Remove([FromRoute] RemoveBook.Request request)
            => await _mediator.Send(request);

    }
}
