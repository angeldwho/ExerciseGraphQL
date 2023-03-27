using ExerciseGraphQL.BLL.Interfaces;
using ExerciseGraphQL.BLL.Models;
using ExerciseGraphQL.DAL;

namespace ExerciseGraphQL.PL.Queries
{
    public class AuthorQuery
    {
        private readonly IAuthorService _authorService;
        public AuthorQuery(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public Task<IAsyncEnumerable<AuthorModel>> GetAuthors()
        {
            return _authorService.GetAllAsync();
        }
    }
}
