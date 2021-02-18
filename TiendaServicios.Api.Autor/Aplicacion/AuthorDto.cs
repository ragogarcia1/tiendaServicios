using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Author.Aplicacion
{
    public class AuthorDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BornDay { get; set; }
        public string BookAuthorGuid { get; set; }
    }
}
