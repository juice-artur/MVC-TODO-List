using System.Collections.Generic;

namespace todo_rest_api.Models
{
    class RepositoryTodoListModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TodoItemList> generalList = new List<TodoItemList>();

    }
}