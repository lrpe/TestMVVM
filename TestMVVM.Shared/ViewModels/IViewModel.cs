using System.ComponentModel;

namespace TestMVVM.Shared.ViewModels
{
    /// <summary>
    /// Viewmodel that notifies clients of property changes.
    /// </summary>
    public interface IViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets a value indicating whether the view model is busy processing information.
        /// </summary>
        bool IsBusy { get; set; }
    }
}
