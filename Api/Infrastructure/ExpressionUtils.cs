﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Api.Infrastructure
{
    public static class ExpressionUtils
    {

        public static IQueryable<T>Where<T>(this IQueryable<T> source, string propertyName, string comparison, object value)
        {
            return source.Where(ExpressionUtils.BuildPredicate<T>(propertyName, comparison, value));
        }
        
        private static Expression<Func<T, bool>> BuildPredicate<T>(string propertyName, string comparison, object value)
        {
            var parameter = Expression.Parameter(typeof(T));

            var left = propertyName.Split('.').Aggregate((Expression)parameter, Expression.PropertyOrField);

            var body = MakeComparison(left, comparison, value);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
        private static IOrderedQueryable<T> MakeOrderExpression<T>(IQueryable<T> source, string propertyName, bool descending)
        {
            var param = Expression.Parameter(typeof(T), string.Empty); 

            var property = Expression.PropertyOrField(param, propertyName);

            var sort = Expression.Lambda(property, param);

            var call = Expression.Call(typeof(Queryable),"OrderBy" + (descending ? "Descending" : string.Empty),
                                 new[] { typeof(T), property.Type }, source.Expression, Expression.Quote(sort));

            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(call);
        }
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName, bool desc)
        {
            return MakeOrderExpression(source, propertyName, desc);
        }

        private static Expression MakeComparison(Expression left, string comparison, object value)
        {
            var constant = Expression.Constant(value, left.Type);

            switch (comparison)
            {
                case "==":
                    return Expression.MakeBinary(ExpressionType.Equal, left, constant);
                case "!=":
                    return Expression.MakeBinary(ExpressionType.NotEqual, left, constant);
                case ">":
                    return Expression.MakeBinary(ExpressionType.GreaterThan, left, constant);
                case ">=":
                    return Expression.MakeBinary(ExpressionType.GreaterThanOrEqual, left, constant);
                case "<":
                    return Expression.MakeBinary(ExpressionType.LessThan, left, constant);
                case "<=":
                    return Expression.MakeBinary(ExpressionType.LessThanOrEqual, left, constant);
                case "Contains":
                case "StartsWith":
                case "EndsWith":

                    if (value is string)
                    {
                        return Expression.Call(left, comparison, Type.EmptyTypes, constant);
                    }

                    throw new NotSupportedException($"Comparison operator '{comparison}' only supported on string.");
                default:
                    throw new NotSupportedException($"Invalid comparison operator '{comparison}'.");
            }
        }
    }
}
