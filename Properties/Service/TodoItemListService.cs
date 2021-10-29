using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace todo_rest_api.Models
{
    public class TodoItemListService
    {
        private List<RepositoryTodoItem> todoRepo = new List<RepositoryTodoItem>    {
                new RepositoryTodoItem() {
                    Id = 1, Title = "First",
                    Tasks = new List<TodoItem>()
                        {
                           new TodoItem() {Id = ++RepositoryTodoItem.LastTaskId, Title = "Task 1, List 1"},
                        }},
                new RepositoryTodoItem() {
                    Id = 2, Title = "Second",
                    Tasks = new List<TodoItem>()
                        {
                           new TodoItem() {Id =  ++RepositoryTodoItem.LastTaskId, Title = "Task 1, List 2"},
                        }}
            };
        private int _lastId = 2;
        public RepositoryTodoItem AddRepository(RepositoryTodoItem repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("item");
            }

            repository.Id = ++_lastId;
            todoRepo.Add(repository);
            return repository;
        }

        public RepositoryTodoItem GetTodoRepository(int id)
        {
            return todoRepo.Find(i => i.Id == id);
        }

        public List<RepositoryTodoItem> GetAllRepository()
        {
            return todoRepo;
        }
        public void RemoveRepo(int id)
        {
            todoRepo.RemoveAll(i => i.Id == id);
        }


        public TodoItem GetTask(int id)
        {
            foreach (var repo in todoRepo)
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
        public Dictionary<string, List<TodoItem>> GetTasks()
        {
            Dictionary<string, List<TodoItem>> tasks = new Dictionary<string, List<TodoItem>>();
            foreach (var todo in todoRepo)
            {
                foreach (var task in todo.Tasks)
                {
                    if(tasks.ContainsKey(todo.Title))
                    {
                        tasks[todo.Title].Add(task);
                    }
                    else
                    {
                        tasks.Add(todo.Title, new List<TodoItem>());
                        tasks[todo.Title].Add(task);
                    }
                }
            }

            return tasks;
        }
        
        public void CreateTaskInRepository(int listId, TodoItem item)
        {
            var listForAddTask = GetTodoRepository(listId);
            item.Id = ++RepositoryTodoItem.LastTaskId;
            listForAddTask.Tasks.Add(item);
        }

        public void PutTodoItem(int id, TodoItem task)
        {
            foreach (var repo in todoRepo)
            {
                for (var i = 0; i < repo.Tasks.Count;  ++i)
                {
                    if (repo.Tasks[i].Id == id)
                    {
                        repo.Tasks[i] = task;
                        repo.Tasks[i].Id = id;
                        return;
                    }
                }

                throw new ArgumentException("Isnt args");
            }
        }
        public void  PatchTodoItem(int taskId, TodoItem task)
        {
            var editableTask = GetTask(taskId);

            editableTask.Title = task?.Title;
            editableTask.DueDate = task?.DueDate;
            editableTask.Description = task?.Description;
            editableTask.Done = task?.Done;
        }

        public void DeleteTodoItem(int id)
        {
            foreach (var repo in todoRepo)
            {
                repo.Tasks.RemoveAll(item => item.Id == id);
            }
        }


    }
}
