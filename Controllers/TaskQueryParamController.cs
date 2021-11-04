using System;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Service;
using Task = todo_rest_api.Model.Task;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskQueryParamController: ControllerBase
    {
        private readonly TasksService _todoItemService;
        public TaskQueryParamController(TasksService service)
        {
            _todoItemService = service;
        }
        
        [HttpGet]
        public ActionResult<Task> GetTask(int id)
        {
            try
            {
                return _todoItemService.GetTask(id);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Task> PostTask(Task task)
        {
            _todoItemService.AddTask(task);
            return Created($"api/todolist/{task.Id}", task);
        }
        [HttpPut]
        public IActionResult PutTask(int id, Task task)
        {
            _todoItemService.PutTodoItem(id, task);

            return Ok();
        }
        
        [HttpPatch]
        public IActionResult PatchTask(int id, Task task)
        {
            _todoItemService.PatchTodoItem(id, task);

            return Ok();
        }

        
        [HttpDelete]
        public ActionResult<Task> DeleteTask(int id)
        {
            _todoItemService.DeleteTodoItem(id);

            return Ok();
        }
        
    }
}