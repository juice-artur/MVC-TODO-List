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
    public class TodoItemController : ControllerBase
    {
        private readonly TodoItemListService _todoItemService;
        public TodoItemController(TodoItemListService service)
        {
            _todoItemService = service;
        }


        [HttpGet("")]
        public Dictionary<string, List<TodoItem>> GetTasks()
        {
            return _todoItemService.GetTasks();
        }


        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTask(int id)
        {
            return _todoItemService.GetTask(id);
        }


        [HttpPost("{listId}")]
        public ActionResult<TodoItem> PostTask(int listId, TodoItem task)
        {
            _todoItemService.CreateTaskInRepository(listId, task);

            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult PutTask(int listId, int id, TodoItem task)
        {
           _todoItemService.PutTodoItem(id, task);

            return Ok();
        }


        [HttpPatch("{listId}/{id}")]
        public IActionResult PatchTask(int id, TodoItem task)
        {
            _todoItemService.PatchTodoItem(id, task);

            return Ok();
        }


        [HttpDelete("{listId}/{id}")]
        public ActionResult<TodoItem> DeleteTask(int id)
        {
            _todoItemService.DeleteTodoItem(id);

            return Ok();
        }
        
    }
}