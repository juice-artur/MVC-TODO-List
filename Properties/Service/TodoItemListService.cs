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
                    tasks = new List<TodoItem>()
                        {
                           new TodoItem() {Id = RepositoryTodoItem.LastTaskId, Title = "Task 1, List 1"},
                        }},
                new RepositoryTodoItem() {
                    Id = 2, Title = "Second",
                    tasks = new List<TodoItem>()
                        {
                           new TodoItem() {Id =  RepositoryTodoItem.LastTaskId, Title = "Task 1, List 2"},
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
                return repo.tasks.Find(item => item.Id == id);
            }

            throw new ArgumentException ("Not find argument");

        }
        public Dictionary<string, List<TodoItem>> GetTasks()
        {
            Dictionary<string, List<TodoItem>> tasks = new Dictionary<string, List<TodoItem>>();
            foreach (var todo in todoRepo)
            {
                foreach (var task in todo.tasks)
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
            item.Id = RepositoryTodoItem.LastTaskId;
            listForAddTask.tasks.Add(item);
        }

        public void PutTodoItem(int listId, int id, TodoItem task)
        {
            var currentTodoList = GetTodoRepository(listId);

            for (int j = 0; j < currentTodoList.tasks.Count; ++j)
            {
                if (currentTodoList.tasks[j].Id == id)
                {
                    task.Id = id;
                    currentTodoList.tasks[j] = task;
                    break;
                }
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
                repo.tasks.RemoveAll(item => item.Id == id);
            }
        }


    }
}
