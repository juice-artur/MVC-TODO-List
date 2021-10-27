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
        private TodoItemService todoItemService;

        public TodoItemController(TodoItemService todoItemService)
        {
            this.todoItemService = todoItemService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            return todoItemService.GetAll();
        }

        [HttpPost("")]
        public ActionResult<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            TodoItem createdItem = todoItemService.Create(todoItem);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

    }
}