using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {

        IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet("getallrooms")]
        public IActionResult GetlAllRooms()
        {
            var result = _roomService.GetAllRooms();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("addroom")]
        public IActionResult AddRoom(Room room)
        {
            var result = _roomService.Add(room);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);

        }


        [HttpPut ("updateroom")]
        public IActionResult UpdateRoom(Room room)
        {
            var result= _roomService.Update(room);
            if (result.Success) { 
            return Ok(result);

            }
            return BadRequest(result.Message);
        }

        [HttpGet("getroombylocationname")]
        public IActionResult GetRoomByLocationName(string locationName)
        {
            var result = _roomService.GetRoomsByLocationName(locationName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getroombylocaitonid")]
        public IActionResult GetRoomById(int id)
        {
            var result = _roomService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getroombycapasity")]
        public IActionResult GetRoomByCapasity(int capasity)
        {
            var result = _roomService.GetRoomsByCapacity(capasity);
            if (result.Success)
            {
                return Ok(result);  
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getroombyequipment")]
        public IActionResult GetRoomByEquipment(List<string>equipmentNames)
        {
            var result = _roomService.GetRoomsByEquipment(equipmentNames);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("removeroom")]
        public IActionResult RemoveRoom(Room room)
        {
            var result = _roomService.Remove(room);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }



     
    }
}
