using ExerciseGraphQL.BLL.Models;
using ExerciseGraphQL.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGraphQL.BLL.Interfaces
{
    public interface IAuthorService
    {
        Task<IAsyncEnumerable<AuthorModel>> GetAllAsync();
        Task<AuthorModel> GetByIdAsync(int id);
        Task<AuthorModel> AddAsync(Author author);
        Task<AuthorModel> UpdateAsync(Author author);

    }
}
