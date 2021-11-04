using System;
using Microsoft.AspNetCore.Mvc;
using todo_rest_api.Model.DTO;
using todo_rest_api.Service;

namespace todo_rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet]
        public ActionResult<DashboardDto> GetCount()
        {
            var a = _dashboardService.GetOpenTaskByList();
            return a;
        }
    }
}