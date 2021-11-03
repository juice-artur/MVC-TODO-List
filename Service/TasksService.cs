using System;
using System.Collections.Generic;
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
            //throw new ArgumentException ("Not find argument");

        }

        /*
        
        public void CreateTaskInList(int listId, Task task)
        {
            var listForAddTask = GetTaskList(listId);
            task.TaskId = ++_lastTaskId;
            listForAddTask.Tasks.Add(task);
        }

        public void PutTodoItem(int id, Task task)
        {
            foreach (var repo in _mainTaskList)
            {
                for (var i = 0; i < repo.Tasks.Count; i++)
                {
                    if (repo.Tasks[i].TaskId == id)
                    {
                        repo.Tasks[i] = task;
                        repo.Tasks[i].TaskId = id;
                        return;
                    }
                }
            }
            throw new ArgumentException("Isn't args");
        }
        public void  PatchTodoItem(int taskId, Task task)
        {
            
            var editableTask = GetTask(taskId);
            editableTask.Title = task.Title == null ?  editableTask.Title : task.Title;
            editableTask.DueDate = task.DueDate == null ?  editableTask.DueDate: task.DueDate;
            editableTask.Description = task.Description == null ?  editableTask.Description : task.Description;
            editableTask.Done = task.Done == null ?  editableTask.Done : task.Done;
        }
        
        public void  PatchList(int listId, TaskList taskList)
        {
            _mainTaskList[listId].TaskListId = listId;

            _mainTaskList[listId].Title = taskList.Title == null ? _mainTaskList[listId].Title : taskList.Title;
        }

        public void DeleteTodoItem(int id)
        {
            foreach (var repo in _mainTaskList)
            {
                repo.Tasks.RemoveAll(item => item.TaskId == id);
            }
        }

        public List<Task> GetAllTasks()
        {
            List<Task> tasks = new List<Task>();
            foreach (var repo in _mainTaskList)
            {
                foreach (var task in repo.Tasks)
                {
                   tasks.Add(task); 
                }
            }

            return tasks;
        }
        */


    }
}
