namespace FunWithSpikes.PardonTheExpression
{
    public static class QueryExt
    {
        public static Query<T> Query<T>(this IDatabase db)
        {
            return new Query<T>(db);
        }
    }
}
