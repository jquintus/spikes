using System;
using System.Linq.Expressions;

namespace FunWithSpikes.PardonTheExpression
{
    public class Where<TSource, TCol> : IWhere
    {
        private readonly Expression<Func<TSource, TCol>> _colSelector;
        private readonly WhereOperator _op;
        private readonly TCol _value;

        public Where(Expression<Func<TSource, TCol>> colSelector, TCol value, WhereOperator op)
        {
            _colSelector = colSelector;
            _value = value;
            _op = op;
        }

        public override string ToString()
        {
            return $"{_colSelector.Format()} {_op} {_value}";
        }
    }
}
