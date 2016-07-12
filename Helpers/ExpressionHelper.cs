using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DevTeam.EntityFrameworkExtensions.Helpers
{
    public static class ExpressionHelper
    {
        public static Expression<Func<TEntity, int>> GetPrimaryKeySelector<TEntity>()
        {
            var property = typeof(TEntity).GetProperty("PrimaryKeySelector", BindingFlags.Static | BindingFlags.Public);
            return property.GetValue(null) as Expression<Func<TEntity, int>>;
        }

        public static Expression<Func<TEntity, bool>> Compare<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> selector, TProperty value)
        {
            var entity = selector.Parameters.First();
            var expression = Expression.Equal(selector.Body, Expression.Constant(value));
            return Expression.Lambda<Func<TEntity, bool>>(expression, entity);
        }

        public static Expression<Func<TEntity, bool>> Search<TEntity>(Expression<Func<TEntity, string>> expression, string searchString)
        {
            var entity = expression.Parameters.First();
            var toLower = Expression.Call(expression.Body, typeof(string).GetMethod("ToLower", Type.EmptyTypes));
            var contains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var compare = Expression.Call(toLower, contains, Expression.Constant(searchString.ToLower()));
            return Expression.Lambda<Func<TEntity, bool>>(compare, entity);
        }

        public static Expression<Func<TEntity, bool>> PkFilterExpression<TEntity>(int id)
        {
            var pkSelector = GetPrimaryKeySelector<TEntity>();
            return Compare(pkSelector, id);
        }

        public static Expression<Func<T, bool>> GetInvertedBoolExpression<T>(string propertyName)
        {
            var instance = Expression.Parameter(typeof(T), "x");

            return Expression.Lambda<Func<T, bool>>(Expression.Not(Expression.Property(instance, propertyName)), instance);
        }

        public static IEnumerable<TModel> AsEnumerable<TModel>(this TModel model)
        {
            yield return model;
        }

        public static string PropertyName<T, P>(this Expression<Func<T, P>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member == null)
            {
                var body = expression.Body as UnaryExpression;
                member = body.Operand as MemberExpression;
            }
            return member.Member.Name;
        }

        public static string PropertyName<T, P>(this Func<T, P> func)
        {
            return func.Method.GetParameters()[0].Name;
        }
    }
}
