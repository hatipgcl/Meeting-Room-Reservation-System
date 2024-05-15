using Business.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : Controller
    {
        IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        [HttpGet("getallequipments")]
        public IActionResult GetAllEquipments()
        {
            var result = _equipmentService.GetAllEquipments();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("addequipment")]
        public IActionResult AddEquipment(Equipment equipment)
        {
            var result = _equipmentService.CreateEquipment(equipment);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);

        }


        [HttpPut("updateequipment")]
        public IActionResult UpdateEquipment(Equipment equipment)
        {
            var result = _equipmentService.UpdateEquipment(equipment);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
        }

  
        [HttpGet("getequipmentbyid")]
        public IActionResult GetEquipmentById(int id)
        {
            var result = _equipmentService.GetEquipmentById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getequipmentbyname")]
        public IActionResult GetEquipmentByName(string name)
        {
            var result = _equipmentService.GetEquipmentByName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }



        [HttpPost("removeequipment")]
        public IActionResult RemoveEquipment(Equipment equipment)
        {
            var result = _equipmentService.DeleteEquipment(equipment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }




    }
}
