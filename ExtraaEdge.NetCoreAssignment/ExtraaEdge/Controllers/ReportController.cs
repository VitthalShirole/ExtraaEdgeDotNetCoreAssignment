using ExtraaEdge.BAL;
using ExtraaEdge.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExtraaEdge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {



        private readonly ApplicationDbContext dbContext;
        private readonly ReportService _service;

        public ReportController(ApplicationDbContext dbContext)

        {
            this.dbContext = dbContext;
            this._service = new ReportService(dbContext);
        }



        [Authorize(Roles = "Admin")]
        [HttpGet("monthly-sales")]

        public async Task<IActionResult> GetMonthlySales([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var result = await _service.GetMonthlySalesReportAsync(fromDate, toDate);
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("brand-sales")]
        public async Task<IActionResult> GetBrandWiseSales([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            var result = await _service.GetBrandWiseSalesReportAsync(fromDate, toDate);
            return Ok(result);
        }


    
    }
}
