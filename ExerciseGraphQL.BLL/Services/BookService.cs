using AutoMapper;
using ExerciseGraphQL.BLL.Interfaces;
using ExerciseGraphQL.BLL.Models;
using ExerciseGraphQL.DAL.Entities;
using ExerciseGraphQL.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGraphQL.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        
        public async Task<IQueryable<BookModel>> GetAllAsync()
        {
            var books = _mapper.Map<IEnumerable<BookModel>>(await _bookRepository.GetAllAsync());
            return books.AsQueryable();
        }

        public async Task<BookModel> GetByIdAsync(int id)
        {
            return _mapper.Map<BookModel>(await _bookRepository.GetByIdAsync(id));
        }

        public async Task<BookModel> AddAsync(Book author)
        {
            return _mapper.Map<BookModel>(await _bookRepository.AddAsync(author));
        }

        public async Task<BookModel> UpdateAsync(Book author)
        {
            var existingAuthor = await _bookRepository.GetByIdAsync(author.ID);

            if (existingAuthor == null)
            {
                return null;
            }

            return _mapper.Map<BookModel>(await _bookRepository.UpdateAsync(existingAuthor));
        }

        public async Task DeleteAsync(int id)
        {
            var existingAuthor = await _bookRepository.GetByIdAsync(id);

            if (existingAuthor == null)
            {
                return;
            }

            await _bookRepository.DeleteAsync(existingAuthor);
        }


    }
}
