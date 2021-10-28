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
        private TodoItemList _todoItemRepository;

        public TodoItemController(TodoItemList todoItemRepository)
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

        [HttpPut("{id}")]
        public ActionResult<TodoItem> RewriteTodoItem(TodoItem todoItem, int id)
        {
            return _todoItemRepository.Rewrite(todoItem, id);
        }
        [HttpPatch("{id}")]
        public ActionResult<TodoItem> UpdateTodoItem(TodoItem item, int id)
        {
            return _todoItemRepository.Update(item, id);
        }




        [HttpPost("")]
        public ActionResult<TodoItem> CreateTodoItem(TodoItem todoItem)
        {
            TodoItem createdItem = _todoItemRepository.Add(todoItem);
            return Created($"api/todoitem/{createdItem.Id}", createdItem);
        }

    }
}