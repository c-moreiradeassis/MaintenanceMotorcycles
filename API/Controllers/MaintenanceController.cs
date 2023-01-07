using Application.Interface;
using Data.Repository.Entity.Context;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceController : ControllerBase
    {
        private MaintenanceService _maintenanceService;

        public MaintenanceController(MaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Maintenance))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddMaintenance(Maintenance maintenance)
        {
            await _maintenanceService.AddMaintenance(maintenance);

            return Ok();
        }
    }
}
