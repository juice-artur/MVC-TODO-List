using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Model;
using todo_rest_api.Service;
using Task = todo_rest_api.Model.Task;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly TasksService _todoItemService;


        public TaskListController(TasksService service)
        {
            this._todoItemService = service;
        }

        [HttpGet("")]
        public ActionResult<List<TaskList>> GetAllTaskList()
        {
            return _todoItemService.GetAllTaskList();
        }
        
        [HttpGet("{listId}")]
        public ActionResult<List<Task>> GetTasksInList(int listId)
        {
            return _todoItemService.GetAllTasksInList(listId);
        }
        

        [HttpPost]
        public ActionResult<TaskList> CreateTodoList(TaskList tasks)
        {
            _todoItemService.AddTaskList(tasks);

            return Created($"api/todolist/{tasks.Id}", tasks);
        }


        [HttpDelete("{listId}")]
        public ActionResult<TaskList> DeleteTaskList(int listId)
        {
            _todoItemService.RemoveTaskList(listId);

            return Ok();
        }
        //
        // [HttpGet("tasks")]
        // public ActionResult<Dictionary<string, List<TodoItem>>> GetTasks()
        // {
        //     return _todoItemService.GetTasks();
        // }
        


        // [HttpPost("task")]
        // public ActionResult<TodoItem> PostTask(int listId, TodoItem task)
        // {
        //     _todoItemService.CreateTaskInRepository(listId, task);
        //
        //     return Created($"api/task/{listId}/{task.Id}", task);
        // }


        // [HttpPut("task")]
        // public IActionResult PutTask(int listId, int taskId, TodoItem task)
        // {
        //     _todoItemService.PutTodoItem(taskId, task);
        //
        //     return Ok();
        // }

        //
        // [HttpPatch("task")]
        // public IActionResult PatchTask(int taskId, TodoItem task)
        // {
        //     _todoItemService.PatchTodoItem(taskId, task);
        //
        //     return Ok();
        // }


        // [HttpDelete("task")]
        // public ActionResult<TodoItem> DeleteTaskById(int taskId)
        // {
        //     _todoItemService.DeleteTodoItem(taskId);
        //
        //     return Ok();
        // }

    }
}