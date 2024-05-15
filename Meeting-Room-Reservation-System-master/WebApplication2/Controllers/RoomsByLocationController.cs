using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class RoomsByLocationController : Controller
    {
        ILocationToRoomsService _roomByLocation;
        public RoomsByLocationController(ILocationToRoomsService locationToRooms)
        {
            _roomByLocation= locationToRooms;
        }

        [HttpGet("getallgroomsbylocation")]
        public IActionResult GetByLocation()
        {
            var result = _roomByLocation.GetLocationToRoom();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }


        [HttpGet("bylocationname")]
        public IActionResult GetByLocationName(string locationName)
        {
            var result = _roomByLocation.GetRoomsByLocationName(locationName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _roomByLocation.GetRoomsByLocationId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
