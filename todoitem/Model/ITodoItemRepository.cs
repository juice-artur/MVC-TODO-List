using System.Collections.Generic;

namespace todo_rest_api.Models
{
    public interface ITodoItemRepository
    {
        List<TodoItem> GetAll();  
        TodoItem Get(int id);
        TodoItem Add(TodoItem item);
        void Remove(int id);
        TodoItem Rewrite(TodoItem item, int id);
        TodoItem Update(TodoItem item, int id);

    }
}