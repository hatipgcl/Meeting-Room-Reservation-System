using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenderController : Controller
    {
        IGenderService _genderService;
        public GenderController(IGenderService genderService)
        {
            _genderService= genderService;
        }

        [HttpGet("getallgeneders")]
        public IActionResult GetlAllGenders()
        {
            var result = _genderService.GetAllGenders();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }


        [HttpGet("getbygendername")]
        public IActionResult GetByGenderName(string genderName)
        {
            var result = _genderService.GetGenderByName(genderName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbygenderid")]
        public IActionResult GetByGenderId(int id)
        {
            var result = _genderService.GetGenderById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


    }
}
