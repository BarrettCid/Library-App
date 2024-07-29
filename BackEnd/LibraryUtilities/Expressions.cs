using Bogus;
using LibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUtilities
{
    public static class Expressions
    {

        public static Expression<Func<Book, bool>> CreateContainsExpression(IDictionary<string, object> filters)
        {
            var paramExp = Expression.Parameter(typeof(Book), "b");
            Expression? body = null;
            foreach (var pair in filters)
            {
                var propExp = Expression.Property(paramExp, pair.Key);
                var value = Expression.Constant(pair.Value, typeof(string));
                MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var containsExpression = Expression.Call(propExp, method, value);
                body = body == null ? containsExpression : Expression.AndAlso(body, containsExpression);
            }
            return Expression.Lambda<Func<Book, bool>>(body, paramExp);
        }
    }
}
