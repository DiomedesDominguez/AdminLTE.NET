// ***********************************************************************
// Assembly         : DNMOFT.Repository
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="IRepository.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace DNMOFT.Repository.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using DNMOFT.DataAccess.Interfaces;

    /// <summary>
    /// Interface IRepository
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <typeparam name="TE">The type of the te.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface IRepository<TE> : IDisposable
        where TE : class, IBaseEntity, new()
    {
        #region Methods

        /// <summary>
        /// Adds for bulk delete.
        /// </summary>
        /// <param name="batchSize">Size of the batch.</param>
        /// <param name="ids">The ids.</param>
        void AddForBulkDelete(ushort batchSize = 50000, params long[] ids);

        /// <summary>
        /// Adds or update.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>TE.</returns>
        TE AddOrUpdate(TE model);

        /// <summary>
        /// Adds the or update bulk.
        /// </summary>
        /// <param name="batchSize">Size of the batch.</param>
        /// <param name="entities">The entities.</param>
        void AddOrUpdateBulk(ushort batchSize = 50000, params TE[] entities);

        /// <summary>
        /// Counts the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>System.Int64.</returns>
        long Count(Expression<Func<TE, bool>> predicate = null);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Delete(long id);

        /// <summary>
        /// Executes the sp.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="parameters">The parameters.</param>
        void ExecuteSp(string storedProcedure, params object[] parameters);

        /// <summary>
        /// Gets the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="maximumRows">The maximum rows.</param>
        /// <param name="startRowIndex">Start index of the row.</param>
        /// <param name="sortExpression">The sort expression.</param>
        /// <returns>IQueryable&lt;TE&gt;.</returns>
        IQueryable<TE> Get(Expression<Func<TE, bool>> predicate = null, int maximumRows = 0, int startRowIndex = 0,
            string sortExpression = null);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TE.</returns>
        TE GetById(long id);

        /// <summary>
        /// Gets the by sp.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IQueryable&lt;TE&gt;.</returns>
        IQueryable<TE> GetBySp(string storedProcedure, params object[] parameters);

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int Save();

        /// <summary>
        /// Saves the bulk.
        /// </summary>
        /// <param name="batchSize">Size of the batch.</param>
        void SaveBulk(ushort batchSize = 50000);

        #endregion Methods
    }
}