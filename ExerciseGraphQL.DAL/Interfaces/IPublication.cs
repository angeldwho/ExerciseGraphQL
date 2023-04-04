using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGraphQL.DAL.Interfaces
{
    public class IPublication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearPublished { get; set; }
    }
}
