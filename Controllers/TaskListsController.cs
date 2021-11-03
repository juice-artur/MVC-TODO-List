using System;
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
        private readonly TaskListsService _taskListsService;

        
        public TaskListController(TaskListsService taskListsService)
        {
            _taskListsService = taskListsService;
        }
        
        [HttpPost]
        public ActionResult<TaskList> CreateTodoList(TaskList tasks)
        {
            _taskListsService.AddTaskList(tasks);

            return Created($"api/todolist/{tasks.TaskListId}", tasks);
        }
        
        [HttpGet("{listId}")]
        public ActionResult<TaskList> GetTasksListById(int listId)
        {
            return _taskListsService.GetTaskListById(listId);
        }
        
        [HttpGet]
        public ActionResult<List<TaskList>> GetAllTasksInList()
        {
            return _taskListsService.GetAllTaskLists();
        }
        
        
        [HttpDelete("{listId}")]
        public ActionResult<TaskList> DeleteTaskList(int listId)
        {
            _taskListsService.RemoveTaskList(listId);
            
            return Ok();
        }

        

        /*[HttpGet]
        public ActionResult<List<TaskList>> GetAllTaskList()
        {
            return _todoItemService.GetAllTaskList();
        }
        
        [HttpPost ("{listId}")]
        public ActionResult<Task> PostTask(int listId, Task task)
        {
            _todoItemService.CreateTaskInList(listId, task);

            return Ok();
        }

        [HttpPatch("{listId}")]
        public void PatchList(int listId, TaskList taskList)
        {
            _todoItemService.PatchList(listId, taskList);
        }*/
            
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