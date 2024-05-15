using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : Controller
    {
        ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("getalllocations")]
        public IActionResult GetlAllLocations()
        {
            var result = _locationService.GetAllLocations();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("addlocation")]
        public IActionResult AddLocation(Location location)
        {
            var result = _locationService.AddLocation(location);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);

        }


        [HttpPut("updatelocation")]
        public IActionResult UpdateLocation(Location location)
        {
            var result = _locationService.UpdateLocation(location);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlocationbyid")]
        public IActionResult GetLocationById(int locationid)
        {
            var result = _locationService.GetLocationById(locationid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }



        [HttpPost("removelocation")]
        public IActionResult RemoveLocation(Location location)
        {
            var result = _locationService.RemoveLocation(location);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }




    }
}

