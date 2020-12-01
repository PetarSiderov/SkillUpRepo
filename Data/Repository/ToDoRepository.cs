using FirstWebApiApp.Data.Interfaces;
using FirstWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWebApiApp.Data.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        List<ToDoItem> toDoList = new List<ToDoItem>();

        public ToDoRepository()
        {
            #region STATIC DATA
            toDoList.AddRange(new List<ToDoItem> {
                new ToDoItem
                {
                    Id = 1,
                    Name = "Create repository layer",
                    IsComplete = true
                },
                new ToDoItem
                {
                    Id = 2,
                    Name = "Create database context",
                    IsComplete = false
                },
                new ToDoItem
                {
                    Id = 3,
                    Name = "Create model classes",
                    IsComplete = true
                }
            });
            #endregion
        }
        #region GET CALLS
        public async Task<List<ToDoItem>> getAllItems()
        {
            return toDoList;
        }
        public async Task<ToDoItem> getItemById(int id)
        {
            ToDoItem item = toDoList.Where(s => s.Id == id).FirstOrDefault();
            if (item != null)
            {
                return item;
            }
            return new ToDoItem();
        }
        #endregion

        #region POST CALLS 
        public async Task<string> createNewItem(ToDoItem toDoItem)
        {
            toDoList.Add(toDoItem);

            return "Item is succefull created";
        }
        #endregion

        #region PUT CALLS 
        public async Task<string> updateItem(ToDoItem toDoItem, int id)
        {
            int? index = toDoList.FindIndex(s => s.Id == id);

            if (index != -1)
            {
                toDoList.RemoveAt((int)index);
                toDoList.Insert((int)index, toDoItem);
                return "Item successfully updated";
            }

            return "Item not found";

        }
        #endregion

        #region DELETE CALLS
        public async Task<string> deleteItem(int id)
        {
            int index = toDoList.FindIndex(s => s.Id == id);
            if(index != -1)
            {
                toDoList.RemoveAt(index);
                return "Item with id " + id + "is successfully deleted";
            }
            return "Item with id " + id + " doesn't exist";
        }
        #endregion
    }
}
