/*using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api.Controllers
{
    public class Dashboard : Controller
    {
        [Route("api/[controller]")]
        [ApiController]
        public class DashboardController
        {
            [HttpGet]
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
        }
     
    }
}*/