using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<T> CombineWithAnd<T>(this Expression<T> expression1, Expression<T> expression2)
        {
            BinaryExpression binaryExpression = Expression.AndAlso(expression1.Body, expression2.Body);

            return Expression.Lambda<T>(binaryExpression, expression1.Parameters[0]);
        }
    }
}
