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

        /*public static implicit operator TaskDto(Task task)
        {
            return new TaskDto()
            {
                List = new TaskListDtoWithoutList(){ TaskListId = task.TaskListId, Title = task.TaskList.Title},
                Description = task.Description, 
                Done = task.Done, Title = task.Title,
                DueDate = task.DueDate, TaskId = task.Id
            };
        }*/
    }
}