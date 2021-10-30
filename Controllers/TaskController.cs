using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Models;
using Task = todo_rest_api.Models.Task;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TasksService _todoItemService;
        public TaskController(TasksService service)
        {
            _todoItemService = service;
        }
        
        [HttpGet("")]
        public ActionResult<List<Task>> GetTasks()
        {
            return _todoItemService.GetAllTasks();
        }


        [HttpGet("{id}")]
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


        [HttpPost("{listId}")]
        public ActionResult<Task> PostTask(int listId, Task task)
        {
            _todoItemService.CreateTaskInList(listId, task);

            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult PutTask(int id, Task task)
        {
           _todoItemService.PutTodoItem(id, task);

            return Ok();
        }


        [HttpPatch("{id}")]
        public IActionResult PatchTask(int id, Task task)
        {
            _todoItemService.PatchTodoItem(id, task);

            return Ok();
        }


        [HttpDelete("{id}")]
        public ActionResult<Task> DeleteTask(int id)
        {
            _todoItemService.DeleteTodoItem(id);

            return Ok();
        }
        
    }
}