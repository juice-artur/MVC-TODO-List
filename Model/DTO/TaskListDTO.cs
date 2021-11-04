using System.Collections.Generic;

namespace todo_rest_api.Model.DTO
{
    public class DashboardDto
    {
        public int TaskTodayCount;
        public List<TaskListDTO> listDto;
    }
    public class TaskListDTO
    {
        public int TaskListId { get; set; }
        public string Title { get; set; }
        public int Count{get; set;}
    }
}