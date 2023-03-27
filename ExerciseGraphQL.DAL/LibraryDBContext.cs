using ExerciseGraphQL.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGraphQL.DAL
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}   
