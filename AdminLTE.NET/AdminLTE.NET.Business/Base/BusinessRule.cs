// ***********************************************************************
// Assembly         : AdminLTE.NET.Business
// Author           : Diomedes Dominguez
// Created          : 2019-08-23
//
// Last Modified By : Diomedes Dominguez
// Last Modified On : 2019-08-23
// ***********************************************************************
// <copyright file="BusinessRule.cs" company="DNMOFT">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace AdminLTE.NET.Business.Base
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    using AutoMapper;

    using AdminLTE.NET.Business.Interface;
    using AdminLTE.NET.DataAccess.Contexts;
    using AdminLTE.NET.DataAccess.Interfaces;
    using AdminLTE.NET.Repository.Interfaces;
    using AdminLTE.NET.ViewModel.Base;
    using AdminLTE.NET.ViewModel.Interfaces;
    using AdminLTE.NET.ViewModel.jTable;

    using LinqKit;

    /// <summary>
    /// Class BusinessRule.
    /// Implements the <see cref="AdminLTE.NET.Business.Interface.IBusinessRule{TR, TE, TV}" />
    /// </summary>
    /// <typeparam name="TR">The type of the tr.</typeparam>
    /// <typeparam name="TE">The type of the te.</typeparam>
    /// <typeparam name="TV">The type of the tv.</typeparam>
    /// <seealso cref="AdminLTE.NET.Business.Interface.IBusinessRule{TR, TE, TV}" />
    public class BusinessRule<TR, TE, TV> : IBusinessRule<TR, TE, TV>
        where TR : class, IRepository<TE>
        where TE : class, IBaseEntity, new()
        where TV : class, IBaseViewModel, new()
    {
        #region Fields

        /// <summary>
        /// The mapper
        /// </summary>
        internal IMapper Mapper;
        /// <summary>
        /// The predicate
        /// </summary>
        internal Expression<Func<TE, bool>> Predicate;

        /// <summary>
        /// The disposed value
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRule{TR, TE, TV}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BusinessRule(ApplicationContext context)
        {
            //Repository = new TR(context);
            Predicate = PredicateBuilder.New<TE>();
            CreateMapping();
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        /// <summary>
        /// Finalizes an instance of the <see cref="BusinessRule{TR, TE, TV}"/> class.
        /// </summary>
        ~BusinessRule()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets or sets the repository.
        /// </summary>
        /// <value>The repository.</value>
        internal TR Repository { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Adds the or update bulk.
        /// </summary>
        /// <param name="batchSize">Size of the batch.</param>
        /// <param name="entitiesDto">The entities dto.</param>
        public virtual void AddOrUpdateBulk(ushort batchSize = 50000, params TV[] entitiesDto)
        {
            if (entitiesDto == null || entitiesDto.Length == 0)
            {
                return;
            }

            TE[] entities = new TE[entitiesDto.Length];

            Mapper.Map(entitiesDto, entities);
            Repository.AddOrUpdateBulk(batchSize, entities);
        }

        /// <summary>
        /// Comboes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>ComboViewModel.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual ComboViewModel Combo(long? id)
        {
            throw new NotImplementedException();

            //if (id.HasValue && id.Value > 0)
            //    Predicate = Predicate.And(x => id.Value == x.Id);
            //var results = Repository.Get(
            //            Predicate,
            //            sortExpression: "Id")
            //        .Select(x => new { x.Name, x.Id })
            //        .ToList()
            //        .Select(x => new OptionsViewModel { DisplayText = x.Name, Value = x.Id });

            //return new ComboViewModel { Options = results };
        }

        /// <summary>
        /// Creates the mapping.
        /// </summary>
        public virtual void CreateMapping()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TV, TE>();
                cfg.CreateMap<TE, TV>();
            });

            Mapper = configuration.CreateMapper();
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>BaseJTableResult.</returns>
        public virtual BaseJTableResult Delete(long id)
        {
            Repository.Delete(id);
            return new BaseJTableResult();
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TE.</returns>
        public virtual ResultViewModel<TV> GetById(long id)
        {
            var entity = Repository.GetById(id);
            var model = new TV();
            Mapper.Map(entity, model);

            return new ResultViewModel<TV>() { Record = model };
        }

        /// <summary>
        /// Lists the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>ResultsViewModel&lt;TV&gt;.</returns>
        public virtual ResultsViewModel<TV> List(RequestViewModel request)
        {
            if (request.jtId.HasValue && request.jtId.Value > 0)
            {
                Predicate = Predicate.And(x => request.jtId.Value == x.Id);
            }

            var result = new ResultsViewModel<TV>()
            {
                TotalRecordCount = Repository.Count(Predicate),
                Records = Repository.Get(Predicate, request.jtPageSize, request.jtStartIndex, request.jtSorting).ToList()
                .Select(x => Mapper.Map(x, new TV()))
                .ToList()
            };
            return result;
        }

        /// <summary>
        /// Saves the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>ResultViewModel&lt;TV&gt;.</returns>
        public virtual ResultViewModel<TV> Save(TV model)
        {
            var entity = new TE();
            Mapper.Map(model, entity);

            entity = Repository.AddOrUpdate(entity);

            Mapper.Map(entity, model);

            return new ResultViewModel<TV>() { Record = model };
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                Repository.Dispose();

                Predicate = null;
                Mapper = null;

                disposedValue = true;
            }
        }

        #endregion Methods
    }
}