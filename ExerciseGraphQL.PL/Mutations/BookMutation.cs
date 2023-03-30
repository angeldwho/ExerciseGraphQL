using ExerciseGraphQL.BLL.Interfaces;
using ExerciseGraphQL.BLL.Models;

namespace ExerciseGraphQL.PL.Mutations
{
    public class BookMutation
    {
        private readonly IBookService _bookService;
        public BookMutation(IBookService bookService)
        {
            _bookService = bookService;
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
