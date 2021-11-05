using System;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Model.DTO;
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

        [HttpPost]
        public ActionResult<Task> PostTask(TaskPostDto task)
        {
            Task t = _todoItemService.AddTask(task);
            
            return Created($"api/todolist/{t.Id}", t);
        }
        [HttpPut]
        public IActionResult PutTask(int id, TaskPostDto task)
        {
            _todoItemService.PutTodoItem(id, task);

            return Ok();
        }
        
        [HttpPatch]
        public IActionResult PatchTask(int id, TaskPostDto task)
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