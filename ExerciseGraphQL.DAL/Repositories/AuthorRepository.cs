using ExerciseGraphQL.DAL.Entities;
using ExerciseGraphQL.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGraphQL.DAL.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly LibraryDBContext _context;
        private readonly DbSet<Author> _dbSet;
        public AuthorRepository(LibraryDBContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Author>();
        }
        public IQueryable<AuthorByCategory> GetMyAuthorsGroupedByCategory()
        {
            var groupedAuthors = _dbSet.GroupBy(o => o.Name);
            return groupedAuthors
                .Select(g => new AuthorByCategory
                {
                    Category = g.Key,
                    Authors = g.ToList()
                });
        }
    }
}
