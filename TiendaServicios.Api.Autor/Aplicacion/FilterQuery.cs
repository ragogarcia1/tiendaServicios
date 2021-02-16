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
        public class UnicAuthor : IRequest<BookAuthor>
        {
            public int BookAuthorId { get; set; }
        }

        public class Manage : IRequestHandler<UnicAuthor, BookAuthor>
        {
            private readonly AuthorContext _contexto;
            public Manage(AuthorContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<BookAuthor> Handle(UnicAuthor request, CancellationToken cancellationToken)
            {
                var author = await _contexto.BookAuthor.Where(x => x.BookAuthorId == request.BookAuthorId).FirstOrDefaultAsync();
                
                if (author == null)
                {
                    throw new Exception("Author Empty");
                }

                return author;
            }
        }
    }
}
