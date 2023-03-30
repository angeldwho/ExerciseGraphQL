﻿using ExerciseGraphQL.BLL.Models;
using ExerciseGraphQL.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGraphQL.BLL.Interfaces
{
    public interface IBookService
    {
        Task<IQueryable<BookModel>> GetAllAsync();
        Task<BookModel> GetByIdAsync(int id);
        Task<BookModel> AddAsync(BookModel book);
        Task<BookModel> UpdateAsync(BookModel book);
        Task DeleteAsync(int id);
    }
}
