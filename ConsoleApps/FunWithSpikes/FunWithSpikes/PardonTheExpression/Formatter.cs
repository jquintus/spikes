using System;
using System.Linq.Expressions;

namespace FunWithSpikes.PardonTheExpression
{
    public static class Formatter
    {
        public static string Format<TSource, TCol>(this Expression<Func<TSource, TCol>> propertyLambda)
        {
            MemberExpression member = propertyLambda.Body as MemberExpression;
            return member.Member.Name;
        }

        public static string Format(this WhereOperator op)
        {
            switch (op)
            {
                case WhereOperator.Equals: return "=";
                case WhereOperator.NotEquals: return "<>";
                case WhereOperator.GreaterThan: return ">";
                case WhereOperator.Etc: return ">, <, etc...";
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
