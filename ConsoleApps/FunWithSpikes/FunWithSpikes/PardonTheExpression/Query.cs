using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FunWithSpikes.PardonTheExpression
{
    public class Query<T>
    {
        public IDatabase Database { get; }

        private readonly List<IWhere> _wheres;

        public Query(IDatabase db)
        {
            // The fact that the query needs to know about 
            // the database is a bit of a hack but can actually 
            // be avoided with a query wrapper.  This was 
            // ommitted because I just wanted to demonstrate the 
            // usage of the query.
            Database = db;
            _wheres = new List<IWhere>();
        }

        public Query<T> Join<TTable, TCol>(
            Expression<Func<T, TTable>> joinerTableSelector,
            Expression<Func<TTable, TCol>> joinerColumnSelector, 
            Expression<Func<T, TCol>> rootColumnSelector)
        {
            // omitted:  creating a Join collection 
            // and keeping track of these calls to build up an actual query
            return this;
        }

        public Query<T> OrderBy<TCol>(Expression<Func<T, TCol>> colSelector)
        {
            // omitted:  creating a order by collection 
            // and keeping track of these calls to build up an actual query
            return this;
        }

        public Query<T> Where<TCol>(Expression<Func<T, TCol>> colSelector, TCol value, WhereOperator op = WhereOperator.Equals)
        {
            _wheres.Add(new Where<T, TCol>(colSelector, value, op));
            return this;
        }

        public string ToSql()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"SELECT * FROM {typeof(T).Name}");

            if (_wheres.Any())
            {
                sb.AppendLine("WHERE");
            }

            var whereSet = _wheres.Select(w => $"    {w}\r\n");
            sb.AppendLine(string.Join(" AND ", whereSet));

            return sb.ToString();
        }
    }
}