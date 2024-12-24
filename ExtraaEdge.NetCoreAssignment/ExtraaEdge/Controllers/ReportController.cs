using ExtraaEdge.DAL;
using javax.xml.ws;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExtraaEdge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;

        public ReportController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost]

        public IActionResult Get([FromBody] RequestWrapper request )
        {
            var handSets = dbContext.handSet.Include(a => a.Brand).ToList();
            return Ok(handSets);
        }

    }
}
