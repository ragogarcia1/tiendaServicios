using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistence;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class New
    {
        public class Eject : IRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime BornDay { get; set; }

        }

        public class EjectValidation : AbstractValidator<Eject>
        {
            public EjectValidation ()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }
        public class Manage : IRequestHandler<Eject>
        {
            public readonly AuthorContext _contexto;

            public Manage(AuthorContext contexto)
            {
                _contexto = contexto;
            }
            public async Task<Unit> Handle(Eject request, CancellationToken cancellationToken)
            {
                var bookAuthor = new BookAuthor
                {
                    Name = request.Name,
                    BornDay = request.BornDay,
                    LastName = request.LastName,
                    BookAuthorGuid = Convert.ToString(Guid.NewGuid())
                };

                _contexto.BookAuthor.Add(bookAuthor);
                var value = await _contexto.SaveChangesAsync();
                
                if(value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Not insert Author");
            }
        }
    }
}
