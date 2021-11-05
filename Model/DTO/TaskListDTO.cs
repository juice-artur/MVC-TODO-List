using System.Collections.Generic;

namespace todo_rest_api.Model.DTO
{
    public class TaskListDto
    {
        public int TaskListId { get; set; }
        public string Title { get; set; }
        public int CountOpenTasks { get; set; }
        
    }
    
}