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
        private TodoItemRepository _todoItemRepository;

        public TodoItemController(TodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItems(int id)
        {
            return _todoItemRepository.Get(id);
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TodoItem>> GetAll()
        {
            return _todoItemRepository.GetAll();
        }

        [HttpPost("")]
        public ActionResult<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            TodoItem createdItem = _todoItemRepository.Add(todoItem);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

    }
}