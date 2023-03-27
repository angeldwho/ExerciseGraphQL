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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<IQueryable<AuthorModel>> GetAllAsync()
        {
            var authors = _mapper.Map<IEnumerable<AuthorModel>>(await _authorRepository.GetAllAsync());
            return authors.AsQueryable();
        }

        public async Task<AuthorModel> GetByIdAsync(int id)
        {
            return _mapper.Map<AuthorModel>(await _authorRepository.GetByIdAsync(id));
        }

        public async Task<AuthorModel> AddAsync(Author author)
        {
            return _mapper.Map<AuthorModel>(await _authorRepository.AddAsync(author));
        }

        public async Task<AuthorModel> UpdateAsync(Author author)
        {
            var existingAuthor = await _authorRepository.GetByIdAsync(author.ID);

            if (existingAuthor == null)
            {
                return null;
            }

            return _mapper.Map<AuthorModel>(await _authorRepository.UpdateAsync(existingAuthor));
        }

        public async Task DeleteAsync(int id)
        {
            var existingAuthor = await _authorRepository.GetByIdAsync(id);

            if (existingAuthor == null)
            {
                return;
            }

            await _authorRepository.DeleteAsync(existingAuthor);
        }
    }
}
