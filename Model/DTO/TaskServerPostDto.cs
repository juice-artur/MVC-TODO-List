using System;

namespace todo_rest_api.Model.DTO
{
    public class TaskServerPostDto
    {
        public int TaskListId{ get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? Done { get; set; }
        
    }
}