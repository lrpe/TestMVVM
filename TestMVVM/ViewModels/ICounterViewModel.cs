using TestMVVM.Shared.ViewModels;

namespace TestMVVM.ViewModels
{
    public interface ICounterViewModel : IViewModel
    {
        int CurrentCount { get; set; }

        void IncrementCount();
    }
}