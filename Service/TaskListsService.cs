using todo_rest_api.Model;

namespace todo_rest_api.Service
{
    public class TaskListsService
    {
        private TaskListContext _context;
        public TaskListsService(TaskListContext context)
        {
            _context = context;
        }
        
        public void AddTaskList(TaskList taskList)
        {
            _context.TaskLists.Add(taskList);
            _context.SaveChanges();
        }

    }
}