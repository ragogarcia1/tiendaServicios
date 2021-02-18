using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistence;
using TiendaServicios.Api.Author.Aplicacion;
using AutoMapper;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Query
    {
        public class AuthorList : IRequest<List<AuthorDto>> { }

        public class Manage : IRequestHandler<AuthorList, List<AuthorDto>>
        {
            private readonly AuthorContext _contexto;
            private readonly IMapper _mapper;
            public Manage(AuthorContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<List<AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _contexto.BookAuthor.ToListAsync();
                var authorsDto = _mapper.Map<List<BookAuthor>, List<AuthorDto>>(authors);
                return authorsDto;
            }
        }
    }
}
