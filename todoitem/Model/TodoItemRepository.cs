using System;
using System.Collections.Generic;

namespace todo_rest_api.Models
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private List<TodoItem> todoItems = new List<TodoItem> { new TodoItem() { Id = 1, Title = "Implement read" } };
        private int lastId = 1;

        public TodoItemRepository()
        {

        }
        public TodoItem Add(TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = ++lastId;
            //item.Description =
            todoItems.Add(item);
            return item;
        }

        public TodoItem Get(int id)
        {
            return todoItems.Find(i => i.Id == id);
        }

        public List<TodoItem> GetAll()
        {
            return todoItems;
        }

        public void Remove(int id)
        {
            todoItems.RemoveAll(i => i.Id == id);
        }

        public bool Update(TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = todoItems.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            todoItems.RemoveAt(index);
            todoItems.Add(item);
            return true;
        }
    }
}