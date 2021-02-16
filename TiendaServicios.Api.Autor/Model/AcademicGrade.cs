using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaServicios.Api.Autor.Modelo
{
    public class AcademicGrade
    {
        public int AcademicGradeId { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime? GradeDate { get; set; }
        public int BookAuthorId { get; set; }
        public BookAuthor BookAuthor { get; set; }
        public string AcademicGradeGuid { get; set; }
    }
}
