using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestMVVM.Shared.ViewModels
{
    /// <summary>
    /// Base class for viewmodels that implements <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public abstract class ViewModelBase : IViewModel
    {
        private bool _isBusy = false;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                SetValue(ref _isBusy, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property raising the event.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = default)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Sets the value of a backing field and raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <remarks>
        /// Will not raise an event if the original value of <paramref name="backingField"/> is equal to
        /// <paramref name="value"/>.
        /// </remarks>
        /// <typeparam name="T">The type of the backing field.</typeparam>
        /// <param name="backingField">The backing field to update.</param>
        /// <param name="value">The new value of the backing field.</param>
        /// <param name="propertyName">The name of the property raising the event.</param>
        protected void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
            {
                return;
            }

            backingField = value;
            OnPropertyChanged(propertyName);
        }
    }
}
