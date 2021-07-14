using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simple.Mediatr.Model.People;
using Simple.Mediatr.Model.People.Commands;
using Simple.Mediatr.Repository.Interface.People;
using System.Threading.Tasks;

namespace Simple.Mediatr.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IPeopleRepository<PeopleModel> _repository;

        public PeopleController(IMediator mediator, IPeopleRepository<PeopleModel> repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        /// <summary>
        /// Busca todas as Pessoas
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _repository.GetAll();
            return Ok(response);
        }

        /// <summary>
        /// Busca apenas uma unica pessoa
        /// </summary>
        /// <returns>
        /// O retorna é objeto Pessoa
        /// </returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return Ok(result);
        }

        /// <summary>
        /// Insere apenas uma Pessoa de cada vez
        /// </summary>
        /// <returns>
        /// O retorno é objeto Pessoa
        /// </returns>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpPost]
        public async Task<IActionResult> Post(CreatePeopleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Altera apenas uma pessoa por objeto
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpPut]
        public async Task<IActionResult> Put(UpdatePeopleCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Deleta um unico registro
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">Bad Request</response>
        /// <response code="500">Internal Server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeletePeopleCommand { PeopleId = id });
            return Ok(response);
        }
    }
}
