using System.Linq;
using Microsoft.EntityFrameworkCore;
using todo_rest_api.Model;
using todo_rest_api.Model.DTO;

namespace todo_rest_api.Service
{
    public class TasksService
    {
        private readonly TaskListContext _context;
        public TasksService(TaskListContext context)
        {
            _context = context;
        }
        
        public Task AddTask(TaskPostDto task)
        {
            var tempTask = new Task
            {
                TaskList = _context.TaskLists.Single(i => i.Id == task.List.TaskListId),
                Description = task.Description,
                Done = task.Done,
                Title = task.Title,
                DueDate = task.DueDate,

            };
            _context.Tasks.Add(tempTask);
            _context.SaveChanges();
            return tempTask;
        }


        public Task AddServerTask(TaskServerPostDto task)
        {
            var tempTask = new Task
            {
                TaskList = _context.TaskLists.Single(i => i.Id == task.TaskListId),
                Description = task.Description,
                Done = task.Done,
                Title = task.Title,
                DueDate = task.DueDate,

            };
            _context.Tasks.Add(tempTask);
            _context.SaveChanges();
            return tempTask;
        }
        
        
        public Task GetTask(int id)
        {
            return _context.Tasks.Include(tl => tl.TaskList).SingleOrDefault(t => t.Id.Equals(id));
        }
        public void PutTodoItem(int id, TaskPostDto task)
        {
            var taskToPut = _context.Tasks.SingleOrDefault(i => i.Id == id);

            if (taskToPut != null)
            {
                taskToPut.Description = task.Description;
                taskToPut.Title = task.Title;
                taskToPut.DueDate = task.DueDate;
                taskToPut.Done = task.Done;
                taskToPut.TaskListId = task.List.TaskListId;
                _context.SaveChanges();
            }
            //throw new ArgumentException("Isn't args");
        }
        
        public void  PatchTodoItem(int taskId, TaskServerPostDto task)
        {
            var  editableTask = _context.Tasks.SingleOrDefault(i => i.Id == taskId);
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
            var taskToRemove = _context.Tasks.SingleOrDefault(i => i.Id == id);

            if (taskToRemove != null)
            {
                _context.Tasks.Remove(taskToRemove);
                _context.SaveChanges();
            }
        }
    }
}
