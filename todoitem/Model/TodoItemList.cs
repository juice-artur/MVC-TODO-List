using System;
using System.Collections.Generic;

namespace todo_rest_api.Models
{
    public class TodoItemList : ITodoItemRepository
    {
        private List<TodoItem> generalTodoItems = new List<TodoItem>();

        private List<TodoItem> todoItems = new List<TodoItem> { new TodoItem() { Id = 1, Title = "Implement read" } };
        private int lastId = 1;

        public TodoItem Add(TodoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = ++lastId;
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

        public TodoItem Rewrite(TodoItem item, int id)
        {

            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = todoItems.FindIndex(p => p.Id == id);
            if (index == -1)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = id;
            todoItems.RemoveAt(index);
            todoItems.Add(item);
            return item;
        }


        public TodoItem Update(TodoItem item, int id)
        {
            int index = todoItems.FindIndex(p => p.Id == id);
            if (item == null)
            {
                if (index != -1)
                {
                    return todoItems[index];
                }
                throw new ArgumentNullException("item");
            }

            item.Id = id;
            if (item.DueDate != DateTime.Now && item.DueDate != todoItems[index].DueDate)
            {
                todoItems[index].DueDate = item.DueDate;
            }
            if (item.Title != "string" && item.Title != todoItems[index].Title)
            {
                todoItems[index].Title = item.Title;
            }
            if (item.Description != "string" && item.Description  != todoItems[index].Description )
            {
                todoItems[index].Description  = item.Description ;
            };
            return todoItems[index];
        }
    }
}
