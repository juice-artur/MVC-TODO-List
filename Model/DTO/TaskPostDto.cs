using System;

namespace todo_rest_api.Model.DTO
{
    public class TaskPostDto
    {
        public  TaskListDtoWithoutList List{ get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Done { get; set; }

        
        
    }
}