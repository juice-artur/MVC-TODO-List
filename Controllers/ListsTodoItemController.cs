using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;
using Task = todo_rest_api.Models.Task;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListsTodoItemController: ControllerBase
    {
        private readonly TasksService _todoItemService;
        public ListsTodoItemController(TasksService service)
        {
            _todoItemService = service;
        }
        

        [HttpGet("")]
        public ActionResult<Task> GetTask(int id)
        {
            return _todoItemService.GetTask(id);
        }

        [HttpPost("")]
        public ActionResult<Task> PostTask(int listId, Task task)
        {
            _todoItemService.CreateTaskInRepository(listId, task);
            return Ok();
        }
        [HttpPut("")]
        public IActionResult PutTask(int id, Task task)
        {
            _todoItemService.PutTodoItem(id, task);

            return Ok();
        }
        
        [HttpPatch("")]
        public IActionResult PatchTask(int id, Task task)
        {
            _todoItemService.PatchTodoItem(id, task);

            return Ok();
        }

        
        [HttpDelete("")]
        public ActionResult<Task> DeleteTask(int id)
        {
            _todoItemService.DeleteTodoItem(id);

            return Ok();
        }
        
    }
}