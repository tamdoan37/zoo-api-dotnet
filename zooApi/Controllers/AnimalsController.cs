using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZooApi.Data;
using ZooApi.Models;

namespace ZooApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly ZooContext _context;

        public AnimalsController(ZooContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            //EF pulls it all automatically
            return await _context.Animals.ToListAsync();
        }
    }
}