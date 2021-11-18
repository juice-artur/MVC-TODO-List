using System;
using System.ComponentModel.DataAnnotations;
using todo_rest_api.Model.DTO;


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
        [System.Text.Json.Serialization.JsonIgnore]
        public TaskList TaskList { get; set; }
    }
}