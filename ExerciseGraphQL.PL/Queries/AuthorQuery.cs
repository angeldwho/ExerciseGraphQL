using ExerciseGraphQL.BLL.Interfaces;
using ExerciseGraphQL.BLL.Models;
using ExerciseGraphQL.DAL;
using ExerciseGraphQL.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExerciseGraphQL.PL.Queries
{
    public class AuthorQuery
    {
        private readonly IAuthorService _authorService;
        public AuthorQuery(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public Task<IQueryable<AuthorModel>> GetAuthors()
        {
            return _authorService.GetAllAsync();
        }
        public Task<AuthorModel> FindSpecificAuthor(int id)
        {
            return _authorService.GetByIdAsync(id);
        }
        public async Task<int> GetAuthorCountAsync()
        {
            return await _authorService.GetCountAsync();
        }
        public IQueryable<AuthorByCategory> GetMyAuthorsGroupedByCategory()
        {
            return _authorService.GetMyObjectsGroupedByCategory();
        }
    }
}
