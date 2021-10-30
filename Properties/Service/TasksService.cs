using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace todo_rest_api.Models
{
    public class TasksService
    {
        private List<RepositoryTasks> todoRepo = new List<RepositoryTasks>    {
                new RepositoryTasks() {
                    Id = 1, Title = "First",
                    Tasks = new List<Task>()
                        {
                           new Task() {Id = ++RepositoryTasks.LastTaskId, Title = "Task 1, List 1"},
                        }},
                new RepositoryTasks() {
                    Id = 2, Title = "Second",
                    Tasks = new List<Task>()
                        {
                           new Task() {Id =  ++RepositoryTasks.LastTaskId, Title = "Task 1, List 2"},
                        }}
            };
        private int _lastId = 2;
        public RepositoryTasks AddRepository(RepositoryTasks repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("item");
            }

            repository.Id = ++_lastId;
            todoRepo.Add(repository);
            return repository;
        }

        public RepositoryTasks GetTodoRepository(int id)
        {
            return todoRepo.Find(i => i.Id == id);
        }

        public List<RepositoryTasks> GetAllRepository()
        {
            return todoRepo;
        }


        public List<Task> GetAllTasksInRepo(int repoId)
        {
            return todoRepo[repoId].Tasks;
        }
        public void RemoveRepo(int id)
        {
            todoRepo.RemoveAll(i => i.Id == id);
        }


        public Task GetTask(int id)
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
        
        public void CreateTaskInRepository(int listId, Task task)
        {
            var listForAddTask = GetTodoRepository(listId);
            task.Id = ++RepositoryTasks.LastTaskId;
            listForAddTask.Tasks.Add(task);
        }

        public void PutTodoItem(int id, Task task)
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
        public void  PatchTodoItem(int taskId, Task task)
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
