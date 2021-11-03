using System;

namespace todo_rest_api.Model
{
    public class Task
    {
        public int TaskId { get; set; }
        public int TaskListId{ get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Done { get; set; }
    }
}