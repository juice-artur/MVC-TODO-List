using System;
using Microsoft.EntityFrameworkCore;
using todo_rest_api.Model;

namespace todo_rest_api
{
    public class TaskListContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }
        
        public TaskListContext(DbContextOptions<TaskListContext> options) : base(options) 
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine);
        }
        
    }
}