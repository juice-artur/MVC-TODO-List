using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using todo_rest_api.Model;
using todo_rest_api.Model.DTO;

namespace todo_rest_api.Service
{
    public class DashboardService
    {
        private readonly TaskListContext _context;

        public DashboardService(TaskListContext context)
        {
            _context = context;
        }

        public DashboardDto GetOpenTaskByList()
        {
            var taskForTodayCount = _context.Tasks.Count(t => t.DueDate.Value.Date.Equals(DateTime.Today.Date));
            var tempListDto = _context.TaskLists.Include(tl => tl.Tasks)
                .Select(l => new TaskListDTO()
                {
                    TaskListId = l.TaskListId, Title = l.Title, Count = l.Tasks.Where(t=> t.Done.Equals(false)).Count()})
                
                .OrderBy(l => l.TaskListId).ToList();
            Console.WriteLine(taskForTodayCount);
            return new DashboardDto() {TaskTodayCount = taskForTodayCount, listDto = tempListDto};
        }
    }
}