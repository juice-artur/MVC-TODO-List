using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;
using Task = todo_rest_api.Models.Task;

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
        
        [HttpGet("")]
        public ActionResult<Task> GetTask(int id)
        {
            try
            {
                return _todoItemService.GetTask(id);
            }
            catch (ArgumentException e)
            {
                return NotFound();
            }
        }

        [HttpPost("")]
        public ActionResult<Task> PostTask(int listId, Task task)
        {
            _todoItemService.CreateTaskInList(listId, task);
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