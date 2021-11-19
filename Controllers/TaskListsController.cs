using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Model;
using todo_rest_api.Model.DTO;
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
        public ActionResult<TaskList> CreateTodoList(TaskListPatchDto taskList)
        {
            TaskList t = _taskListsService.AddTaskList(taskList);

            return Created($"api/todolist/{t.Id}", t);
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

        [HttpPatch("{listId}")]
        public IActionResult PatchList(int listId, TaskListPatchDto taskList)
        {
            _taskListsService.PatchList(listId, taskList);
            return Ok();
        }
        [HttpGet("{listId}/tasks")]
        public List<Task> GetTaskInList(int listId, bool isOpen)
        {
            return _taskListsService.GetTaskInList(listId,isOpen);
        }

        [HttpGet("{listId}/all-tasks")]
        public List<Task> GetAllTaskInList(int listId)
        {
            return _taskListsService.GetTaskInList(listId,false);
        }
        
        
    }
}