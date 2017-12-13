using System.Collections.Generic;

namespace FunWithSpikes.PardonTheExpression
{
    public interface IDatabase
    {
        IEnumerable<T> Execute<T>(string sql);

    }
}
