using System.Collections.Generic;
using System.Linq;
using todo_rest_api.Model;

namespace todo_rest_api.Service
{
    public class TaskListsService
    {
        private readonly TaskListContext _context;
        public TaskListsService(TaskListContext context)
        {
            _context = context;
        }
        
        public void AddTaskList(TaskList taskList)
        {
            _context.TaskLists.Add(taskList);
            _context.SaveChanges();
        }

        public TaskList GetTaskListById(int listId)
        {
            return _context.TaskLists.Find(listId);
        }
        
        public List<TaskList> GetAllTaskLists()
        {
            return _context.TaskLists.ToList();
        }
        
        public void RemoveTaskList(int id)
        {
            var taskListToRemove = _context.TaskLists.SingleOrDefault(i => i.TaskListId == id);

            if (taskListToRemove != null)
            {
                _context.TaskLists.Remove(taskListToRemove);
                _context.SaveChanges();
            }
            
        }
        
        public void  PatchList(int listId, TaskList taskList)
        {
            
            var taskListToUpdate = _context.TaskLists.SingleOrDefault(i => i.TaskListId == listId);

            if (taskListToUpdate != null)
            {
                taskListToUpdate.Title = taskList.Title;
                _context.SaveChanges();
            }
        }

        public List<Task> GetTaskInList(int listId, bool isOpen)
        {
            if (!isOpen)
            {
                return _context.Tasks.Where(t => t.TaskListId == listId).ToList();
            }
            else
            {
                return _context.Tasks.Where(t => t.TaskListId == listId).Where(t=>t.Done == false).ToList();
            }
        }
    }
}