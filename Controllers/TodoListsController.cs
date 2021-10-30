using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;
using Task = todo_rest_api.Models.Task;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly TasksService _todoItemService;


        public TodoListController(TasksService service)
        {
            this._todoItemService = service;
        }

        [HttpGet("")]
        public ActionResult<List<RepositoryTasks>> GetTasks()
        {
            return _todoItemService.GetAllRepository();
        }

        [HttpGet("{repoId}")]
        public ActionResult<List<Task>> GetTasksInRepo(int repoId)
        {
            return _todoItemService.GetAllTasksInRepo(repoId);
        }
        

        [HttpPost]
        public ActionResult<RepositoryTasks> CreateTodoList(RepositoryTasks tasks)
        {
            _todoItemService.AddRepository(tasks);

            return Created($"api/todolist/{tasks.Id}", tasks);
        }


        [HttpDelete("{repoId}")]
        public ActionResult<RepositoryTasks> DeleteTodoItemById(int repoId)
        {
            _todoItemService.RemoveRepo(repoId);

            return Ok();
        }
        //
        // [HttpGet("tasks")]
        // public ActionResult<Dictionary<string, List<TodoItem>>> GetTasks()
        // {
        //     return _todoItemService.GetTasks();
        // }
        


        // [HttpPost("task")]
        // public ActionResult<TodoItem> PostTask(int listId, TodoItem task)
        // {
        //     _todoItemService.CreateTaskInRepository(listId, task);
        //
        //     return Created($"api/task/{listId}/{task.Id}", task);
        // }


        // [HttpPut("task")]
        // public IActionResult PutTask(int listId, int taskId, TodoItem task)
        // {
        //     _todoItemService.PutTodoItem(taskId, task);
        //
        //     return Ok();
        // }

        //
        // [HttpPatch("task")]
        // public IActionResult PatchTask(int taskId, TodoItem task)
        // {
        //     _todoItemService.PatchTodoItem(taskId, task);
        //
        //     return Ok();
        // }


        // [HttpDelete("task")]
        // public ActionResult<TodoItem> DeleteTaskById(int taskId)
        // {
        //     _todoItemService.DeleteTodoItem(taskId);
        //
        //     return Ok();
        // }

    }
}