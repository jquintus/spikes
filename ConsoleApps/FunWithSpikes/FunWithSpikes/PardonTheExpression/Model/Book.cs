namespace FunWithSpikes.PardonTheExpression.Model
{
    public class Book
    {
        public Person Author { get; set; }
        public int AuthorId { get; set; }
        public Genre Genre { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public int PubYear { get; set; }
    }
}
