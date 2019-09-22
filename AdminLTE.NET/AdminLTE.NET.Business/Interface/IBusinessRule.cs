// ***********************************************************************
// Assembly         : AdminLTE.NET.Business
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="IBusinessRule.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.Business.Interface
{
    using AdminLTE.NET.DataAccess.Interfaces;
    using AdminLTE.NET.Repository.Interfaces;
    using AdminLTE.NET.ViewModel.Base;
    using AdminLTE.NET.ViewModel.Interfaces;
    using AdminLTE.NET.ViewModel.jTable;
    using System;

    /// <summary>
    /// Interface IBusinessRule
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <typeparam name="TR">The type of the repository.</typeparam>
    /// <typeparam name="TE">The type of the entity.</typeparam>
    /// <typeparam name="TV">The type of the tv.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public interface IBusinessRule<TR, TE, TV> : IDisposable
        where TR : class, IRepository<TE>
        where TE : class, IBaseEntity, new()
        where TV : class, IBaseViewModel, new()
    {
        #region Methods
        void CreateMapping();

        /// <summary>
        /// Adds the or update bulk.
        /// </summary>
        /// <param name="batchSize">Size of the batch.</param>
        /// <param name="entities">The entities.</param>
        void AddOrUpdateBulk(ushort batchSize = 50000, params TV[] entitiesDto);

        /// <summary>
        /// Comboes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ComboViewModel.</returns>
        ComboViewModel Combo(long? id);


        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BaseJTableResult.</returns>
        BaseJTableResult Delete(long id);

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TE.</returns>
        ResultViewModel<TV> GetById(long id);

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ResultsViewModel&lt;TV&gt;.</returns>
        ResultsViewModel<TV> List(RequestViewModel request);

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ResultViewModel&lt;TV&gt;.</returns>
        ResultViewModel<TV> Save(TV model);


        #endregion Methods
    }
}