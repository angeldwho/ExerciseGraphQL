using ExerciseGraphQL.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGraphQL.DAL.Entities
{
    public class Magazine : IPublication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
    }
}
