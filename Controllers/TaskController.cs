using System;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Model;
using todo_rest_api.Model.DTO;
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
        
/*        [HttpPost]
        public IActionResult PostTask(TaskPostDto task)
        {
            Task t = _todoItemService.AddTask(task);
            
            return Created($"api/todolist/{t.Id}", t);
        }*/




        [HttpPost]
        public IActionResult PostTask(TaskServerPostDto task)
        {
            Task t = _todoItemService.AddServerTask(task);
            
            return Created($"api/todolist/{t.Id}", t);
        }
        
        
        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetTask(int id)
        {
            try
            {
                return TaskDto.ToTaskDto(_todoItemService.GetTask(id));
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }


            


        [HttpPut("{id}")]
        public IActionResult PutTask(int id, TaskPostDto task)
        {
            _todoItemService.PutTodoItem(id, task);

            return Ok();
        }
        
        [HttpPatch("{id}")]
        public IActionResult PatchTask(int id, TaskPostDto task)
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