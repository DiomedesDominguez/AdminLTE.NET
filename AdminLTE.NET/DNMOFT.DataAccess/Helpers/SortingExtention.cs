// ***********************************************************************
// Assembly         : DNMOFT.DataAccess
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="SortingExtention.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.DataAccess.Helpers
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Class SortingExtention.
    /// </summary>
    public static class SortingExtention
    {
        #region Methods

        /// <summary>
        /// Sorts the by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="value">The value.</param>
        /// <returns>IOrderedQueryable&lt;T&gt;.</returns>
        public static IOrderedQueryable<T> SortBy<T>(this IQueryable<T> source, string value)
        {
            var properties = value.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            IOrderedQueryable<T> result = null;
            for (var i = 0; i < properties.Length; i++)
            {
                var property = properties[i].Trim();
                var descending = property.ToUpper().Contains(" DESC");

                property = property.Replace(" DESC", string.Empty).Replace(" ASC", string.Empty).Replace(" ", string.Empty);
                if (i == 0)
                {
                    result = descending ? source.OrderByDescending(property) : source.OrderBy(property);
                }
                else
                {
                    result = descending ? result.ThenByDescending(property) : result.ThenBy(property);
                }
            }
            return result;
        }

        /// <summary>
        /// Applies the order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="property">The property.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns>IOrderedQueryable&lt;T&gt;.</returns>
        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            var props = property.Split('.');
            var type = typeof(T);
            var arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (var prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                var pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            var delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            var lambda = Expression.Lambda(delegateType, expr, arg);

            var result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                              && method.IsGenericMethodDefinition
                              && method.GetGenericArguments().Length == 2
                              && method.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), type)
                .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }

        /// <summary>
        /// Orders the by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="property">The property.</param>
        /// <returns>IOrderedQueryable&lt;T&gt;.</returns>
        private static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "OrderBy");
        }

        /// <summary>
        /// Orders the by descending.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="property">The property.</param>
        /// <returns>IOrderedQueryable&lt;T&gt;.</returns>
        private static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "OrderByDescending");
        }

        /// <summary>
        /// Thens the by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="property">The property.</param>
        /// <returns>IOrderedQueryable&lt;T&gt;.</returns>
        private static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "ThenBy");
        }

        /// <summary>
        /// Thens the by descending.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="property">The property.</param>
        /// <returns>IOrderedQueryable&lt;T&gt;.</returns>
        private static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder(source, property, "ThenByDescending");
        }

        #endregion Methods
    }
}