using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using todo_rest_api.Model;
using todo_rest_api.Model.DTO;

namespace todo_rest_api.Service
{
    public class CollectionService
    {
        private readonly TaskListContext _context;

        public CollectionService(TaskListContext context)
        {
            _context = context;
        }

        public List<TaskTodayDTO> GetTasksForToday()
        {
            return  _context.TaskLists.Include(tl => tl.Tasks).Select(l => new TaskTodayDTO()
            {
                TaskListId = l.TaskListId, Title = l.Title, listTitle =  l.Tasks.Single(i => i.TaskListId== l.TaskListId).Title, Description = l.Tasks.Single(i => i.TaskListId== l.TaskListId).Description, TaskId = l.Tasks.Single(i => i.TaskListId== l.TaskListId).TaskId, DueDate = l.Tasks.Single(i => i.TaskListId== l.TaskListId).DueDate, Done = l.Tasks.Single(i => i.TaskListId== l.TaskListId).Done
            }).ToList();
        } 
    }
}