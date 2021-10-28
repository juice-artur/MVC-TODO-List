using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/tasks/")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TodoItemListService _todoItemService;
        public TaskController(TodoItemListService service)
        {
            _todoItemService = service;
        }


        [HttpGet("")]
        public Dictionary<string, List<TodoItem>> GetTasks()
        {
            return _todoItemService.GetTasks();
        }


        [HttpGet("{listId}/{id}")]
        public ActionResult<TodoItem> GetTask(int listId, int id)
        {
            return _todoItemService.GetTask(listId, id);
        }


        [HttpPost("{listId}")]
        public ActionResult<TodoItem> PostTask(int listId, TodoItem task)
        {
            _todoItemService.CreateTaskInRepository(listId, task);

            return Ok();
        }


        [HttpPut("{listId}/{id}")]
        public IActionResult PutTask(int listId, int id, TodoItem task)
        {
           _todoItemService.PutTodoItem(listId, id, task);

            return Ok();
        }


        [HttpPatch("{listId}/{id}")]
        public IActionResult PatchTask(int listId, int id, TodoItem task)
        {
            _todoItemService.PatchTodoItem(listId, id, task);

            return Ok();
        }


        [HttpDelete("{listId}/{id}")]
        public ActionResult<TodoItem> DeleteTask(int listId, int id)
        {
            _todoItemService.DeleteTodoItem(listId, id);

            return Ok();
        }
        
    }
}