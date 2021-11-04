using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;
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
        
        public int GetTaskListDto()
        {
            return (_context.Tasks.Count(t => t.DueDate >= DateTime.Today && t.DueDate <= DateTime.Today.AddDays(1)));
        }

        public List<TaskListDTO> GetAllList()
        {
        }
        
    }
}