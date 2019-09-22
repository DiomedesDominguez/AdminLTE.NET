namespace AdminLTE.NET.ViewModel.jTable
{
    using System.Collections.Generic;

    using AdminLTE.NET.ViewModel.Base;

    public class ResultsViewModel<TE> : BaseJTableResult
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the records.
        /// </summary>
        /// <value>The records.</value>
        public IEnumerable<TE> Records { get; set; }

        /// <summary>
        ///     Gets or sets the total record count.
        /// </summary>
        /// <value>The total record count.</value>
        public long TotalRecordCount { get; set; }

        #endregion Properties
    }
}