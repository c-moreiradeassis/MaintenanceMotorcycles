using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddMaintenance(MaintenanceImp maintenance)
        {


            return Ok();
        }
    }
}
