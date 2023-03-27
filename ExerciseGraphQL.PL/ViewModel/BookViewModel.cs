namespace ExerciseGraphQL.PL.ViewModel
{
    public class BookViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public AuthorViewModel Author { get; set; }
    }
}
