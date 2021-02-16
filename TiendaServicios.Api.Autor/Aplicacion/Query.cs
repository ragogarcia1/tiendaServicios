using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Query
    {
        public class AuthorList : IRequest<List<BookAuthor>> { }

        public class Manage : IRequestHandler<AuthorList, List<BookAuthor>>
        {
            private readonly AuthorContext _contexto;
            public Manage(AuthorContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<List<BookAuthor>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var Authors = await _contexto.BookAuthor.ToListAsync();
                return Authors;
            }
        }
    }
}
