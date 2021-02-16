using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Autor.Modelo
{
    public class BookAuthor
    {
        public int BookAuthorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BornDay { get; set; }
        public ICollection<AcademicGrade> ListAcademicGrade { get; set; }
        public string BookAuthorGuid { get; set; }

    }
}
