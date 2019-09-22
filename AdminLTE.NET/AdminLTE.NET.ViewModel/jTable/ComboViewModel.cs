namespace AdminLTE.NET.ViewModel.jTable
{
    using System.Collections.Generic;

    using Base;

    public class ComboViewModel : BaseJTableResult
    {
        #region Properties

        public IEnumerable<OptionsViewModel> Options { get; set; }

        #endregion Properties
    }
}