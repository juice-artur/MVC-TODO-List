using System;
using System.Collections.Generic;
using System.Linq;
using todo_rest_api.Model;

namespace todo_rest_api.Service
{
    public class TasksService
    {
        private TaskListContext _context;
        public TasksService(TaskListContext context)
        {
            _context = context;
        }
        
        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }
        
        
        public Task GetTask(int id)
        {
            return _context.Tasks.Find(id);

        }
        public void PutTodoItem(int id, Task task)
        {
            var taskToPut = _context.Tasks.SingleOrDefault(i => i.TaskId == id);

            if (taskToPut != null)
            {
                taskToPut.Description = task.Description;
                taskToPut.Title = task.Title;
                taskToPut.DueDate = task.DueDate;
                taskToPut.Done = task.Done;
                taskToPut.TaskListId = task.TaskListId;
                _context.SaveChanges();
            }
            //throw new ArgumentException("Isn't args");
        }
        
        public void  PatchTodoItem(int taskId, Task task)
        {
            var  editableTask = _context.Tasks.SingleOrDefault(i => i.TaskId == taskId);
            if (editableTask != null)
            {
                editableTask.TaskListId =  task.TaskListId == null ?  editableTask.TaskListId : task.TaskListId;
                editableTask.Title = task.Title == null ?  editableTask.Title : task.Title;
                editableTask.DueDate = task.DueDate == null ?  editableTask.DueDate: task.DueDate;
                editableTask.Description = task.Description == null ?  editableTask.Description : task.Description;
                editableTask.Done = task.Done == null ?  editableTask.Done : task.Done;
                _context.SaveChanges();   
            }
        }
        
        public void DeleteTodoItem(int id)
        {
            var taskToRemove = _context.Tasks.SingleOrDefault(i => i.TaskId == id);

            if (taskToRemove != null)
            {
                _context.Tasks.Remove(taskToRemove);
                _context.SaveChanges();
            }
        }
    }
}
