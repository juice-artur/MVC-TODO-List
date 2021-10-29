   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoRepositoryController : ControllerBase
    {
        private TodoItemListService todoItemService;


        public TodoRepositoryController(TodoItemListService service)
        {
            this.todoItemService = service;
        }


        [HttpGet("")]
        public ActionResult<IEnumerable<RepositoryTodoItem>> GetTodoItems()
        {
            return todoItemService.GetAllRepositori();
        }


        [HttpGet("list")]
        public ActionResult<RepositoryTodoItem> GetTodoListById(int listId)
        {
            return todoItemService.GetTodoRepository(listId);
        }


        [HttpPost("")]
        public ActionResult<RepositoryTodoItem> CreateTodoList(RepositoryTodoItem todoItem)
        {
            todoItemService.AddTodoItem(todoItem);

            return Created($"api/todolist/{todoItem.Id}", todoItem);
        }


        [HttpDelete("list")]
        public ActionResult<RepositoryTodoItem> DeleteTodoItemById(int listId)
        {
            todoItemService.Remove(listId);

            return Ok();
        }

        [HttpGet("tasks")]
        public ActionResult<Dictionary<string, List<TodoItem>>> GetTasks()
        {
            return todoItemService.GetTasks();
        }

        
        [HttpGet("task")]
        public ActionResult<TodoItem> GetTask(int listId, int taskId)
        {
            return todoItemService.GetTask(listId, taskId);
        }


        [HttpPost("task")]
        public ActionResult<TodoItem> PostTask(int listId, TodoItem task)
        {
            todoItemService.CreateTaskInRepository(listId, task);

            return Created($"api/task/{listId}/{task.Id}", task);
        }


        [HttpPut("task")]
        public IActionResult PutTask(int listId, int taskId, TodoItem task)
        {
            todoItemService.PutTodoItem(listId, taskId, task);

            return Ok();
        }


        [HttpPatch("task")]
        public IActionResult PatchTask(int listId, int taskId, TodoItem task)
        {
            todoItemService.PatchTodoItem(listId, taskId, task);

            return Ok();
        }


        [HttpDelete("task")]
        public ActionResult<TodoItem> DeleteTaskById(int listId, int taskId)
        {
            todoItemService.DeleteTodoItem(listId, taskId);

            return Ok();
        }

    }
}