using FunWithSpikes.PardonTheExpression.Model;

namespace FunWithSpikes.PardonTheExpression
{
    public static class QueryRunner
    {
        public static void Run()
        {
            var db = new Database();
            var people = db.Query<Person>()
                           .Where(p => p.Name, "Andy Weir")
                           .Where(p => p.Rating, 99, WhereOperator.GreaterThan)
                           .Execute();

            var books = db.Query<Book>()
                          .Where(b => b.Title, "Time Machine")
                          .Where(b => b.Genre, Genre.ScienceFact)
                          .Execute();

            var booksAndAuthors = db.Query<Book>()
                                    .Join(
                                        b => b.Author,
                                        a => a.Id,
                                        b => b.AuthorId)
                          .Where(b => b.Author.Name, "Dr. Science")
                          .OrderBy(b => b.PubYear)
                          .OrderBy(b => b.Author.Rating)
                          .Execute();
        }
    }
}
