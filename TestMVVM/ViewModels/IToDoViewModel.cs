using System.Collections.Generic;
using System.Threading.Tasks;
using TestMVVM.Shared.ViewModels;

namespace TestMVVM.ViewModels
{
    public interface IToDoViewModel : IViewModel
    {
        ToDoItem ToDoItem { get; set; }
        List<ToDoItem> ToDoList { get; set; }

        Task DeleteToDoAsync(ToDoItem toDoItem);
        Task SaveToDoAsync();
    }
}