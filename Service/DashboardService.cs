/*using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore.Internal;

namespace todo_rest_api.Model.DTO
{
    public class DashboardService
    {
        private readonly TaskListContext _context;

        public DashboardService(TaskListContext context)
        {
            _context = context;
        }

        public int NumberOfTasksForToday()
        {
            return _context.Tasks.LeftJoin(_context.TaskLists, task => task.TaskListId, list => list.TaskListId,
                (task, list) => new
                {
                    done = task.Done

                }).GroupBy(task.done = false);
        }
    }
}*/