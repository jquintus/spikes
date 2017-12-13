using FunWithSpikes.PardonTheExpression.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
