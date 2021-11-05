using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Model;
using todo_rest_api.Model.DTO;
using todo_rest_api.Service;

namespace todo_rest_api.Controllers
{
    [Route("api/collection")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly CollectionService _service;

        public CollectionController(CollectionService service)
        {
            _service = service;
        }

        [HttpGet("today")]
        public IEnumerable<TaskDto> GetTask()
        {
            return _service.GetTasksForToday().Select(TaskDto.ToTaskDto);
        }
    }
}