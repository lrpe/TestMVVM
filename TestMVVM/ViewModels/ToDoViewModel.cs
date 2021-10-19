using System.Collections.Generic;
using System.Threading.Tasks;
using TestMVVM.Shared.ViewModels;

namespace TestMVVM.ViewModels
{
    public class ToDoViewModel : ViewModelBase, IToDoViewModel
    {
        private List<ToDoItem> _toDoList = new();
        public List<ToDoItem> ToDoList
        {
            get => _toDoList;
            set
            {
                SetValue(ref _toDoList, value);
            }
        }

        private ToDoItem _toDoItem = new();
        public ToDoItem ToDoItem
        {
            get => _toDoItem;
            set
            {
                SetValue(ref _toDoItem, value);
            }
        }

        public async Task SaveToDoAsync()
        {
            IsBusy = true;
            await Task.Delay(500);
            _toDoList.Add(ToDoItem);
            _toDoItem = new();
            OnPropertyChanged(nameof(ToDoList));
            IsBusy = false;
        }

        public async Task DeleteToDoAsync(ToDoItem toDoItem)
        {
            IsBusy = true;
            await Task.Delay(500);
            _toDoList.Remove(toDoItem);
            OnPropertyChanged(nameof(ToDoList));
            IsBusy = false;
        }
    }
}
