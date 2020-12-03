using FirstWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApiApp.Data.Interfaces
{
    public interface IToDoRepository
    {
        Task<List<ToDoItem>> getAllItems();
        Task<ToDoItem> getItemById(int id);
        Task<string> createNewItem(ToDoItem toDoItem);
        Task<string> updateItem(ToDoItem toDoItem, int id);
        Task<string> deleteItem(int id);





    }
}
