using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]/{listId}/tasks")]
    [ApiController]
    public class ListsTodoItemController
    {
        private TodoItemListService _todoItemService;
        public ListsTodoItemController(TodoItemListService service)
        {
            _todoItemService = service;
        }


        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTask(int id)
        {
            return _todoItemService.GetTask(id);
        }
        
    }
}