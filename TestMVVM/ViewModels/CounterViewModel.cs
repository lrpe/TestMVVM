using TestMVVM.Shared.ViewModels;

namespace TestMVVM.ViewModels
{
    public class CounterViewModel : ViewModelBase, ICounterViewModel
    {
        private int _currentCount = 0;
        public int CurrentCount
        {
            get => _currentCount;
            set
            {
                SetValue(ref _currentCount, value);
            }
        }

        public void IncrementCount()
        {
            CurrentCount++;
        }
    }
}
