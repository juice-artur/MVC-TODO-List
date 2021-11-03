using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Model;
using todo_rest_api.Service;

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
        
        /*[HttpGet]
        public ActionResult<List<Task>> GetTasks()
        {
            return _todoItemService.GetAllTasks();
        }

        [HttpPut("{id}")]
        public IActionResult PutTask(int id, Task task)
        {
           _todoItemService.PutTodoItem(id, task);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Task> DeleteTask(int id)
        {
            _todoItemService.DeleteTodoItem(id);

            return Ok();
        }
        */
        [HttpPost]
        public IActionResult PostTask(Task task)
        {
            _todoItemService.AddTask(task);
            return Created($"api/todolist/{task.TaskId}", task);
        }
        
        [HttpGet("{id}")]
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

    }
}