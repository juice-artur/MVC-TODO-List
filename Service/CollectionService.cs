using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using todo_rest_api.Model;

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
            return _context.Tasks.Include(tl => tl.TaskList).
                Where(t => (t.Done ==false) && (t.DueDate.Value.Date <= DateTime.Today.Date)).ToList();
            
        } 
    }
}