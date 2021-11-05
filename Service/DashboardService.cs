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

        public DashboardDto GetOpenTaskByListSQL()
        {
            string query = "SELECT task_lists.Id,task_lists.title, COUNT(tasks.done) FROM task_lists " +
                           "LEFT JOIN tasks ON tasks.task_list_id = task_list_id " +
                           "WHERE tasks IS Null OR tasks.done = 'false' " +
                           "GROUP BY task_lists.Id " +
                           "ORDER BY task_lists.Id ";

            DashboardDto dd = new DashboardDto();
            dd.TaskTodayCount = _context.Tasks
                .Count(t => t.DueDate.Value.Date
                    .Equals(DateTime.Today.Date) && t.Done == (false));
            dd.listDto = new List<TaskListDto>();
            using var conn = new NpgsqlConnection(_context.Database.GetConnectionString());
            conn.Open();
            
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        TaskListDto tempObj = new TaskListDto();
                        tempObj.TaskListId = reader.GetInt32(0);
                        tempObj.Title = reader.GetString(1);
                        tempObj.Count = reader.GetInt32(2);
                        dd.listDto.Add(tempObj);
                    }
            }
            conn.Close();
            return dd;
        }

        public DashboardDto GetOpenTaskByList()
        {
            var taskForTodayCount = _context.Tasks.Count(t => t.DueDate.Value.Date.Equals(DateTime.Today.Date));
            var tempListDto = _context.TaskLists.Include(tl => tl.Tasks)
                .Select(l => new TaskListDto()
                {
                    TaskListId = l.Id, Title = l.Title, Count = l.Tasks.Count(t => t.Done.Equals(false))})
                
                .OrderBy(l => l.TaskListId).ToList();
            return new DashboardDto() {TaskTodayCount = taskForTodayCount, listDto = tempListDto};
            
        }
    }
}