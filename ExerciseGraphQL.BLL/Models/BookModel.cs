using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseGraphQL.BLL.Models
{
    public class BookModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }
}
