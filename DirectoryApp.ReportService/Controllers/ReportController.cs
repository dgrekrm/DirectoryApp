using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryApp.ReportService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase {

        [HttpGet]
        public IActionResult GetReport() {
            return Ok(new { message = "success" });
        } 
    }
}
