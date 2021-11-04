using System;
//using System.Linq;
using System.Collections.Generic;
using System.Linq;
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
                    TaskListId = l.Id, Title = l.Title, Count = l.Tasks.Count(t => t.Done.Equals(false))})
                
                .OrderBy(l => l.TaskListId).ToList();
            return new DashboardDto() {TaskTodayCount = taskForTodayCount, listDto = tempListDto};

            /*var taskForTodayCount = _context.Tasks.FromSqlRaw("SELECT count(*) FROM tasks WHERE tasks.due_date BETWEEN '2021-11-03' AND '2021-11-05' GROUP BY DATE(tasks.due_date)");
            List<Task> temp = _context.Tasks.FromSqlRaw(
                "select task_lists.task_list_id,task_lists.title, count(tasks.done) from tasks right join task_lists on tasks.task_list_id=task_lists.task_list_id where done=false or tasks is Null group by task_lists.task_list_id").ToList();
            return new DashboardDto() {TaskTodayCount = Convert.ToInt32(taskForTodayCount), listDto = (TaskListDTO)temp};*/
        }
    }
}