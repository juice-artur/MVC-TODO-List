using System;
using System.ComponentModel.DataAnnotations;


namespace todo_rest_api.Model
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public int TaskListId{ get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Done { get; set; }
        public TaskList TaskList { get; set; }
    }
}