using System;
using System.Collections.Generic;
using todo_rest_api.Model;

namespace todo_rest_api.Service
{
    public class TasksService
    {
        private readonly List<TaskList> _mainTaskList = new List<TaskList>    {
                new TaskList() {
                    Id = 0, Title = "First",
                    Tasks = new List<Task>()
                        {
                           new Task() {Id = 0, Title = "Task 1, List 1"},
                        }},
                new TaskList() {
                    Id = 1, Title = "Second",
                    Tasks = new List<Task>()
                        {
                           new Task() {Id =  1, Title = "Task 1, List 2"},
                        }}
            };
        private int _lastListId = 1;
        private int _lastTaskId = 1;
        public TaskList AddTaskList(TaskList taskList)
        {
            if (taskList == null)
            {
                throw new ArgumentNullException(nameof(taskList));
            }

            taskList.Id = ++_lastListId;
            _mainTaskList.Add(taskList);
            return taskList;
        }

        public TaskList GetTaskList(int id)
        {
            return _mainTaskList.Find(i => i.Id == id);
        }

        public List<TaskList> GetAllTaskList()
        {
            return _mainTaskList;
        }


        public List<Task> GetAllTasksInList(int taskListId)
        {
            return _mainTaskList[taskListId].Tasks;
        }
        public void RemoveTaskList(int id)
        {
            _mainTaskList.RemoveAll(i => i.Id == id);
        }


        public Task GetTask(int id)
        {
            foreach (var repo in _mainTaskList)
            {
                foreach (var task in repo.Tasks)
                {
                    if (task.Id == id)
                    {
                        return task;
                    }
                }
            }

            throw new ArgumentException ("Not find argument");

        }
        
        public void CreateTaskInList(int listId, Task task)
        {
            var listForAddTask = GetTaskList(listId);
            task.Id = ++_lastTaskId;
            listForAddTask.Tasks.Add(task);
        }

        public void PutTodoItem(int id, Task task)
        {
            foreach (var repo in _mainTaskList)
            {
                for (var i = 0; i < repo.Tasks.Count; i++)
                {
                    if (repo.Tasks[i].Id == id)
                    {
                        repo.Tasks[i] = task;
                        repo.Tasks[i].Id = id;
                        return;
                    }
                }
            }
            throw new ArgumentException("Isn't args");
        }
        public void  PatchTodoItem(int taskId, Task task)
        {
            
            var editableTask = GetTask(taskId);

            editableTask.Title = task?.Title;
            editableTask.DueDate = task?.DueDate;
            editableTask.Description = task?.Description;
            editableTask.Done = task?.Done;
        }
        
        public void  PatchList(int listId, TaskList taskList)
        {
            _mainTaskList[listId].Id = listId;

            _mainTaskList[listId].Title = taskList?.Title;
        }

        public void DeleteTodoItem(int id)
        {
            foreach (var repo in _mainTaskList)
            {
                repo.Tasks.RemoveAll(item => item.Id == id);
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


    }
}
