using System.Collections.Generic;

namespace todo_rest_api.Models
{
    public class RepositoryTodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int LastTaskId{ get; set; }
        public List<TodoItem> tasks = new List<TodoItem>();

    }
}