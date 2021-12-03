using System;
//using System.Linq;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Npgsql;
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
                .Select(l => new TaskListDto()
                {
                    TaskListId = l.Id, Title = l.Title, CountOpenTasks = l.Tasks.Count(t => t.Done.Equals(false))})
                
                .OrderBy(l => l.TaskListId).ToList();
            return new DashboardDto() {TaskTodayCount = taskForTodayCount, Lists = tempListDto};
            
        }
    }
}