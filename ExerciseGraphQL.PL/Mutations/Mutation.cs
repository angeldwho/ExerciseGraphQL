using ExerciseGraphQL.BLL.Interfaces;
using ExerciseGraphQL.BLL.Models;
using ExerciseGraphQL.DAL.Entities;

namespace ExerciseGraphQL.PL.Mutations
{
    public class Mutation
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        public Mutation(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
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
        public async Task<BookModel> AddBook(string title, int author)
        {
            var book = new BookModel { Title = title };
            return await _bookService.AddAsync(book);
        }

        public async Task<BookModel> UpdateBook(int id, string title, int author)
        {
            var book = new BookModel { ID = id, Title = title };
            return await _bookService.UpdateAsync(book);
        }

        public async Task<bool> DeleteBook(int id)
        {
            await _bookService.DeleteAsync(id);
            return true;
        }
    }
}
