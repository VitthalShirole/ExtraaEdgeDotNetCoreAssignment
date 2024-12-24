using ExtraaEdge.BAL;
using ExtraaEdge.DAL;
using ExtraaEdge.DAL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExtraaEdge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HandSetController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public HandSetController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]

        public IActionResult Get()
        {
            var handSets = dbContext.handSet.Include(a => a.Brand).ToList();
            return Ok(handSets);
        }

        [HttpPost]
        public IActionResult Add(HandSet handSet)
        {
            var result = new HandSetService(dbContext).Add(handSet);

            return Ok(result);
        }

        [HttpGet("{brandId}")]
        public IActionResult Get(int brandId)
        {
            var result = new HandSetService(dbContext).Get(brandId);

            return Ok(result);
        }
    }
}