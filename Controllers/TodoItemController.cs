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
        public IActionResult PutTask(int id, TodoItem task)
        {
           _todoItemService.PutTodoItem(id, task);

            return Ok();
        }


        [HttpPatch("{id}")]
        public IActionResult PatchTask(int id, TodoItem task)
        {
            _todoItemService.PatchTodoItem(id, task);

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<TodoItem> DeleteTask(int id)
        {
            _todoItemService.DeleteTodoItem(id);

            return Ok();
        }
        
    }
}