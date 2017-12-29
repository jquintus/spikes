using System.Collections.Generic;
using System.Linq;

namespace FunWithSpikes.PardonTheExpression
{
    public class Database : IDatabase
    {
        public IEnumerable<T> Execute<T>(string sql)
        {
            return Enumerable.Empty<T>();
        }
    }
}
