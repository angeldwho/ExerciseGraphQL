using ExerciseGraphQL.BLL.Interfaces;
using ExerciseGraphQL.BLL.Models;
using ExerciseGraphQL.DAL;
using ExerciseGraphQL.DAL.Entities;
using ExerciseGraphQL.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExerciseGraphQL.PL.Queries
{
    public class Query
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        public Query(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
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
        public Task<IQueryable<BookModel>> GetBooks()
        {
            return _bookService.GetAllAsync();
        }
        public Task<BookModel> FindSpecificBook(int id)
        {
            return _bookService.GetByIdAsync(id);
        }

    }
}
