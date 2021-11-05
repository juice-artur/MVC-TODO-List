using System;

namespace todo_rest_api.Model.DTO
{
    public class TaskDto
    {
        public  TaskListDtoWithoutList List{ get; set;}
        public int? TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Done { get; set; }
        public static TaskDto ToTaskDto(Task task)
        {
            return new TaskDto()
            {
                List = new TaskListDtoWithoutList{ TaskListId = task.TaskListId, Title = task.TaskList.Title},
                Description = task.Description, 
                Done = task.Done, Title = task.Title,
                DueDate = task.DueDate, TaskId = task.Id
            };
        }
        
    }
}