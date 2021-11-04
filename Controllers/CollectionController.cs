using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
        public List<TaskTodayDTO> GetTask()
        {
            return _service.GetTasksForToday();
        }
    }
}