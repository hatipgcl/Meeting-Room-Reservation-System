using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StafftitleController : Controller
    {
        IStafftitleService _stafftitleservice;
        public StafftitleController(IStafftitleService stafftitleservice)
        {
            _stafftitleservice = stafftitleservice;
        }

        [HttpGet("getallstafftitles")]
        public IActionResult GetAllStafftitle()
        {
            var result = _stafftitleservice.GetAllStafftitles();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("addStafftitle")]
        public IActionResult AddRoom(Stafftitle stafftitle)
        {
            var result = _stafftitleservice.Add(stafftitle);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);

        }


        [HttpPut("updatestafftitle")]
        public IActionResult UpdateStafftitle(Stafftitle stafftitle)
        {
            var result = _stafftitleservice.Update(stafftitle);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
        }

        [HttpGet("getstafftitlebyname")]
        public IActionResult GetStafftitleByName(string stafftitleName)
        {
            var result = _stafftitleservice.GetStafftitlesByName(stafftitleName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getstafftitlebyid")]
        public IActionResult GetStafftitleById(int id)
        {
            var result = _stafftitleservice.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("removestafftitle")]
        public IActionResult RemoveStafftitle(Stafftitle stafftitle)
        {
            var result = _stafftitleservice.Remove(stafftitle);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
