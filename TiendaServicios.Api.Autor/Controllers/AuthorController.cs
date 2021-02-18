using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Author.Aplicacion;
using TiendaServicios.Api.Autor.Aplicacion;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<Unit>> Create(New.Eject data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> AuthorsGet()
        {
            return await _mediator.Send(new Query.AuthorList());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<AuthorDto>> GetBookAuthor(int id)
        {
            return await _mediator.Send(new FilterQuery.UnicAuthor{ BookAuthorId = id });
        }
    }
}
