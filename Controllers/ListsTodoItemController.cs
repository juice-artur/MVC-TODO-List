using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]/{listId}/tasks")]
    [ApiController]
    public class ListsTodoItemController: ControllerBase
    {
        private readonly TodoItemListService _todoItemService;
        public ListsTodoItemController(TodoItemListService service)
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

        [HttpPost("")]
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