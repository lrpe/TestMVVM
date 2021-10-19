using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using TestMVVM.Shared.ViewModels;

namespace TestMVVM.Shared.Components
{
    /// <summary>
    /// Base component that has a viewmodel injected and calls <see cref="ComponentBase.StateHasChanged"/>
    /// whenever updates occur.
    /// </summary>
    /// <remarks>
    /// Exposes an <see cref="OnViewModelUpdate"/> lifecycle method, which is called when updates occur
    /// and is responsible for calling <see cref="ComponentBase.StateHasChanged"/>.
    /// </remarks>
    /// <typeparam name="TModel">The type of viewmodel that this component uses.</typeparam>
    public abstract class ViewModelComponent<TModel> : ComponentBase, IDisposable
        where TModel : IViewModel
    {
        /// <summary>
        /// This viewmodel of this component.
        /// </summary>
        [Inject]
        public TModel ViewModel { get; set; }

        public void Dispose()
        {
            ViewModel.PropertyChanged -= (o, e) => OnViewModelUpdate();
            GC.SuppressFinalize(this);
        }

        protected override Task OnInitializedAsync()
        {
            ViewModel.PropertyChanged += (o, e) => OnViewModelUpdate();
            return base.OnInitializedAsync();
        }

        /// <summary>
        /// Method invoked when the viewmodel of the component is updated, causing
        /// <see cref="ComponentBase.StateHasChanged"/> to be invoked and the component to be re-rendered.
        /// </summary>
        /// <remarks>
        /// When overridden, it is up to client code to call <c>base.OnViewModelUpdate()</c> for re-rendering to occur.
        /// </remarks>
        protected virtual void OnViewModelUpdate()
        {
            this.StateHasChanged();
        }
    }
}
