using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;
namespace todo_rest_api.Controllers
{
    public class TodoRepositoryController
    {
        [Route("api/[controller]")]
        [ApiController]
        public class TodoListController : ControllerBase
        {
            private TodoItemListService _todoItemService;


            public TodoListController(TodoItemListService service)
            {
                _todoItemService = service;
            }


            [HttpGet("")]
            public ActionResult<Dictionary<string, List<TodoItem>>> GetTodoItems(int listId)
            {
                return _todoItemService.GetTasks();
            }


            [HttpGet("{listId}")]
            public ActionResult<RepositoryTodoItem> GetTodoList(int listId)
            {
                return _todoItemService.GetTodoRepository(listId);
            }


            [HttpPost("")]
            public ActionResult<RepositoryTodoItem> CreateTodoItem(RepositoryTodoItem todoItem)
            {
                _todoItemService.AddTodoItem(todoItem);

                return Created($"api/todolist/{todoItem.Id}", todoItem);
            }


            [HttpDelete("{id}")]
            public ActionResult<TodoItem> DeleteRepository(int id)
            {
                _todoItemService.Remove(id);

                return Ok();
            }
        }
    }
}