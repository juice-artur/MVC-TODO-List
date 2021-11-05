using System.Collections.Generic;

namespace todo_rest_api.Model.DTO
{
    public class DashboardDto
    {
        public int TaskTodayCount { get; set; }
        public List<TaskListDto> ListDto { get; set; }
    }
}