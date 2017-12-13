using System.Collections.Generic;

namespace FunWithSpikes.PardonTheExpression
{
    public static class QueryExt
    {
        public static Query<T> Query<T>(this IDatabase db)
        {
            return new Query<T>(db);
        }

        public static IEnumerable<T> Execute<T>(this Query<T> query)
        {
            var sql = query.ToSql();
            return query.Database.Execute<T>(sql);
        }
    }
}
