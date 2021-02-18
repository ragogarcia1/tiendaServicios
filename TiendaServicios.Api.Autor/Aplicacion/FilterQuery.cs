using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Author.Aplicacion
{
    public class FilterQuery
    {
        public class UnicAuthor : IRequest<AuthorDto>
        {
            public int BookAuthorId { get; set; }
        }

        public class Manage : IRequestHandler<UnicAuthor, AuthorDto>
        {
            private readonly AuthorContext _contexto;
            private readonly IMapper _mapper;
            public Manage(AuthorContext contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async Task<AuthorDto> Handle(UnicAuthor request, CancellationToken cancellationToken)
            {
                var author = await _contexto.BookAuthor.Where(x => x.BookAuthorId == request.BookAuthorId).FirstOrDefaultAsync();
                
                if (author == null)
                {
                    throw new Exception("Author Empty");
                }

                var authorDto = _mapper.Map<BookAuthor, AuthorDto>(author);

                return authorDto;
            }
        }
    }
}
