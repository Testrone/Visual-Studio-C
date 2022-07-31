using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static WebApplication2.Services.AnimalServices;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalControllers : ControllerBase
    {
        private IDatabaseService _dbService;

        public AnimalControllers(IDatabaseService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("api/animals")]

        public IActionResult GetAnimals(string sortowanier)
        {
            if(string.IsNullOrEmpty(sortowanier) || sortowanier == "name" || sortowanier == "description" || sortowanier == "category" || sortowanier == "area")
                return Ok(_dbService.GetAnimals(sortowanier));
            else return BadRequest("Maniane odjebałeś");
        }

    }
}
