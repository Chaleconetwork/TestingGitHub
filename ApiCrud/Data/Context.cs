using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}
    }
}
