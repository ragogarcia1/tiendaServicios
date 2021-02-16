using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiendaServicios.Api.Autor.Modelo;

namespace TiendaServicios.Api.Autor.Persistence
{
    public class AuthorContext : DbContext
    {
        public AuthorContext(DbContextOptions<AuthorContext> options) : base(options)
        {

        }

        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<AcademicGrade> AcademicGrade { get; set; }
    }
}
