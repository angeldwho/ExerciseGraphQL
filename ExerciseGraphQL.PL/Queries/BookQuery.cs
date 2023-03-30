using ExerciseGraphQL.BLL.Interfaces;
using ExerciseGraphQL.BLL.Models;
using ExerciseGraphQL.DAL.Entities;

namespace ExerciseGraphQL.PL.Queries
{
    public class BookQuery
    {
        private readonly IBookService _bookService;
        public BookQuery(IBookService bookService)
        {
            _bookService = bookService;
        }
        public Task<IQueryable<BookModel>> GetAuthors()
        {
            return _bookService.GetAllAsync();
        }
        public Task<BookModel> FindSpecificAuthor(int id)
        {
            return _bookService.GetByIdAsync(id);
        }
    }
}
