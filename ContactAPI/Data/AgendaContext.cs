using ContactAPI.Entities;
using Microsoft.EntityFrameworkCore; 

namespace ContactAPI.Data
{
    public class AgendaContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }
    }
}
