using System.Collections.Generic;
using todo_rest_api.Models;
namespace todo_rest_api
{
    public class TodoItemService
    {
        private List<TodoItem> todoItems = new List<TodoItem>();
        private int lastId = 0;
        public List<TodoItem> GetAll()
        {
            return todoItems;
        }

        public TodoItem Create(TodoItem item)
        {
            item.Id = ++lastId;
            todoItems.Add(item);
            return item;
        }
    }
}