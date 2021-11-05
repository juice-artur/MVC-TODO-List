using System;
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
        
        public List<Task> GetTasksForToday()
        {
            return _context.Tasks.Include(tl => tl.TaskList).Where(t => t.DueDate.Value.Date.Equals(DateTime.Today.Date)).ToList();
            
            /*return  _context.TaskLists.Include(tl => tl.Tasks).Select(l => new TaskTodayDTO()
            {
                TaskListId = l.Id, Title = l.Title, listTitle =  l.Tasks.Single(i => i.TaskListId== l.Id).Title, Description = l.Tasks.Single(i => i.TaskListId== l.Id).Description, TaskId = l.Tasks.Single(i => i.TaskListId== l.Id).Id, DueDate = l.Tasks.Single(i => i.TaskListId== l.Id).DueDate, Done = l.Tasks.Single(i => i.TaskListId== l.Id).Done
            }).ToList();*/
        } 
    }
}