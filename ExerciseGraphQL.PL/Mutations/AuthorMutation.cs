using ExerciseGraphQL.BLL.Interfaces;
using ExerciseGraphQL.BLL.Models;
using ExerciseGraphQL.DAL.Entities;

namespace ExerciseGraphQL.PL.Mutations
{
    public class AuthorMutation
    {
        private readonly IAuthorService _authorService;
        public AuthorMutation(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<AuthorModel> AddAuthor(string input)
        {
            var author = new AuthorModel { Name = input };
            return await _authorService.AddAsync(author);
        }

        public async Task<AuthorModel> UpdateAuthor(int id, string input)
        {
            var author = new AuthorModel { ID = id, Name = input };
            return await _authorService.UpdateAsync(author);
        }

        public async Task<bool> DeleteAuthor(int id)
        {
            await _authorService.DeleteAsync(id);
            return true;
        }
    }
}
