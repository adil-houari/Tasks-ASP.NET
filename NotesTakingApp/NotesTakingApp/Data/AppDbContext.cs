using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace NotesTakingApp.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLlocalDB;Database=NotesDB;");
        }
    }
}
