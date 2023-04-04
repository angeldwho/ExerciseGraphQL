﻿using ExerciseGraphQL.DAL.Entities;
using ExerciseGraphQL.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGraphQL.DAL.Repositories
{
    public class MagazineRepository : GenericRepository<Magazine>, IMagazineRepository
    {
        public MagazineRepository(LibraryDBContext context) : base(context)
        {

        }
    }
}
