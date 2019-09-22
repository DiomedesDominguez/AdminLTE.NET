// ***********************************************************************
// Assembly         : AdminLTE.NET.Repository
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="Repository.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.Repository.Base
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Linq.Expressions;

    using AdminLTE.NET.DataAccess.Contexts;
    using AdminLTE.NET.DataAccess.Enums;
    using AdminLTE.NET.DataAccess.Helpers;
    using AdminLTE.NET.DataAccess.Interfaces;
    using AdminLTE.NET.Repository.Interfaces;

    using LinqKit;

    /// <summary>
    /// Class Repository.
    /// Implements the <see cref="AdminLTE.NET.Repository.Interfaces.IRepository{TE}" />
    /// </summary>
    /// <typeparam name="TE">The type of the te.</typeparam>
    /// <seealso cref="AdminLTE.NET.Repository.Interfaces.IRepository{TE}" />
    public class Repository<TE> : IRepository<TE>
        where TE : class, IBaseEntity, new()
    {
        #region Fields

        /// <summary>
        /// The database context
        /// </summary>
        internal ApplicationContext DbContext;

        /// <summary>
        /// The EntityTable
        /// </summary>
        internal DbSet<TE> DbSet;

        /// <summary>
        /// The disposed
        /// </summary>
        private bool disposed = false;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TE}" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(ApplicationContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<TE>();
        }

        // the finalizer
        /// <summary>
        /// Finalizes an instance of the <see cref="Repository{TE}"/> class.
        /// </summary>
        ~Repository()
        {
            Dispose(false);
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Adds for bulk delete.
        /// </summary>
        /// <param name="batchSize">Size of the batch.</param>
        /// <param name="ids">The ids.</param>
        public virtual void AddForBulkDelete(ushort batchSize = 50000, params long[] ids)
        {
            var entities = DbSet.AsExpandable()
                .Where(x => x.RecordState != RecordState.Deleted && ids.Contains(x.Id)).ToList();
            entities.ForEach(x => { x.RecordState = RecordState.Deleted; });

            AddOrUpdateBulk(batchSize, entities.ToArray());
        }

        /// <summary>
        /// Adds the entity or update it to the database.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>TE.</returns>
        public virtual TE AddOrUpdate(TE model)
        {
            if (model.Id == 0)
            {
                model.CreatedAt = DateTime.Now;
                model.CreatedBy = DbContext.UserId;
            }

            model.LastModifiedAt = DateTime.Now;
            model.LastModifiedBy = DbContext.UserId;

            model.ClientIp = DbContext.ClientIp;

            DbSet.AddOrUpdate(model);

            Save();

            //Useful to get the complete structure of the model involved.
            model = GetById(model.Id);
            return model;
        }

        /// <summary>
        /// Adds the or update bulk.
        /// </summary>
        /// <param name="batchSize">Size of the batch.</param>
        /// <param name="entities">The entities.</param>
        public virtual void AddOrUpdateBulk(ushort batchSize = 50000, params TE[] entities)
        {
            entities.ForEach(x =>
            {
                x.CreatedAt = DateTime.Now;
                x.CreatedBy = DbContext.UserId;

                x.LastModifiedAt = DateTime.Now;
                x.LastModifiedBy = DbContext.UserId;
                x.ClientIp = DbContext.ClientIp;
            });

            DbContext.BulkMerge(entities, operation =>
            {
                operation.BatchSize = batchSize;
                operation.IgnoreOnMergeUpdateExpression = entity => new { entity.CreatedAt, entity.CreatedBy };
            });
        }

        /// <summary>
        /// Counts the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>System.Int64.</returns>
        public virtual long Count(Expression<Func<TE, bool>> predicate = null)
        {
            return DbSet.AsExpandable().LongCount(StateExpression(predicate));
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public virtual void Delete(long id)
        {
            var model = GetById(id);
            if (model == null)
            {
                return;
            }

            model.RecordState = RecordState.Deleted;

            AddOrUpdate(model);
        }

        // Implement IDisposable
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="command">The command.</param>
        public virtual void ExecuteNonQuery(string command)
        {
            DbContext.Database.ExecuteSqlCommand(command);
        }

        /// <summary>
        /// Executes the sp.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="parameters">The parameters.</param>
        public virtual void ExecuteSp(string storedProcedure, params object[] parameters)
        {
            var command = $"EXECUTE {storedProcedure} ";
            command = parameters.Aggregate(command, (current, t) => string.Concat(current, " '", t, "', "));
            command = command.Remove(command.Length - 2);
            DbContext.Database.ExecuteSqlCommand(command);
        }

        /// <summary>
        /// Gets the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="maximumRows">The maximum rows.</param>
        /// <param name="startRowIndex">Start index of the row.</param>
        /// <param name="sortExpression">The sort expression.</param>
        /// <returns>IQueryable&lt;TE&gt;.</returns>
        public virtual IQueryable<TE> Get(Expression<Func<TE, bool>> predicate = null, int maximumRows = 0,
            int startRowIndex = 0, string sortExpression = null)
        {
            var queryable = DbSet.AsExpandable().Where(StateExpression(predicate)).AsExpandable();

            if (!string.IsNullOrEmpty(sortExpression))
            {
                queryable = queryable.SortBy(sortExpression).AsQueryable();
            }

            if (maximumRows > 0 && startRowIndex >= 0)
            {
                queryable = queryable.Skip(startRowIndex).Take(maximumRows);
            }

            return queryable;
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TE.</returns>
        public virtual TE GetById(long id)
        {
            var model = DbSet.Find(id);
            return model;
        }

        /// <summary>
        /// Gets the by sp.
        /// </summary>
        /// <param name="storedProcedure">The stored procedure.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>IQueryable&lt;TE&gt;.</returns>
        public virtual IQueryable<TE> GetBySp(string storedProcedure, params object[] parameters)
        {
            var command = $"EXECUTE {storedProcedure} ";
            command = parameters.Aggregate(command, (current, t) => string.Concat(current, " '", t, "', "));
            if (parameters.Length != 0)
            {
                command = command.Remove(command.Length - 2);
            }

            var result = DbContext.Database.SqlQuery<TE>(command).AsQueryable();
            return result;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns>System.Int32.</returns>
        public virtual int Save()
        {
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// Saves the bulk.
        /// </summary>
        /// <param name="batchSize">Size of the batch.</param>
        public virtual void SaveBulk(ushort batchSize = 50000)
        {
            if (batchSize <= 20000)
            {
                batchSize = 20000;
            }

            DbContext.BulkSaveChanges(false, operation => { operation.BatchSize = batchSize; });
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
                DbSet = null;
                DbContext.Dispose();
                disposed = true;
            }
        }

        /// <summary>
        /// States the expression.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Expression&lt;Func&lt;TE, System.Boolean&gt;&gt;.</returns>
        private Expression<Func<TE, bool>> StateExpression(Expression<Func<TE, bool>> predicate = null)
        {
            if (predicate == null)
            {
                predicate = PredicateBuilder.New<TE>();
            }

            return predicate;
        }

        #endregion Methods
    }
}