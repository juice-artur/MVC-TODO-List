using System;
using System.Collections.Generic;

namespace todo_rest_api.Models
{
    public class TodoItemListService
    {
        private List<RepositoryTodoItem> todoItems = new List<RepositoryTodoItem>    {
                new RepositoryTodoItem() {
                    Id = 1, Title = "First", LastTaskId = 1,
                    tasks = new List<TodoItem>()
                        {
                           new TodoItem() {Id = 1, Title = "Task 1, List 1"},
                        }},
                new RepositoryTodoItem() {
                    Id = 2, Title = "Second", LastTaskId = 1,
                    tasks = new List<TodoItem>()
                        {
                           new TodoItem() {Id = 1, Title = "Task 1, List 2"},
                        }}
            };
        private int lastId = 2;
        public RepositoryTodoItem AddTodoItem(RepositoryTodoItem repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("item");
            }

            repository.Id = ++lastId;
            todoItems.Add(repository);
            return repository;
        }

        public RepositoryTodoItem GetTodoRepository(int id)
        {
            return todoItems.Find(i => i.Id == id);
        }

        public List<RepositoryTodoItem> GetAllRepositori()
        {
            return todoItems;
        }
        public void Remove(int id)
        {
            todoItems.RemoveAll(i => i.Id == id);
        }


        public TodoItem GetTask(int listId, int id)
        {
            List<TodoItem> tasks = GetTodoRepository(listId).tasks;

            return tasks.Find(x => x.Id == id);
        }
        public Dictionary<string, List<TodoItem>> GetTasks()
        {
            Dictionary<string, List<TodoItem>> tasks = new Dictionary<string, List<TodoItem>>();
            foreach (var todo in todoItems)
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
            item.Id = ++listForAddTask.LastTaskId;
            listForAddTask.tasks.Add(item);
        }
        ////

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
        ////
        public void PatchTodoItem(int listId, int taskId, TodoItem task)
        {
            var editableTask = GetTask(listId, taskId);

            editableTask.Title = task?.Title;
            editableTask.DueDate = task?.DueDate;
            editableTask.Description = task?.Description;
            editableTask.Done = task?.Done;
        }

        public void DeleteTodoItem(int listId, int id)
        {
            var removeTask = GetTask(listId, id);

            GetTodoRepository(listId).tasks.Remove(removeTask);
        }


    }
}
