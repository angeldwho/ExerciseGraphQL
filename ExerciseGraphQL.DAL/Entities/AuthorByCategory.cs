using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGraphQL.DAL.Entities
{
    public class AuthorByCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public List<Author> Authors { get; set; }
    }
}
