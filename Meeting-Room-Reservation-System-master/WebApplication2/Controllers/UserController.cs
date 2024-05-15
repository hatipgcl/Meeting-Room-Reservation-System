using Business.Abstract;
using Core.Entities.Concrete;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        IUserService _userService;
        IGenderService _genderService;
        
        IStafftitleService _stafftitleService;
        public UserController(IUserService userService,IGenderService genderService,IStafftitleService stafftitleService)
        {
            _userService = userService;
            _genderService = genderService;
         
            _stafftitleService = stafftitleService;
        }


        [HttpGet("getallusers")]
        public IActionResult GetlAllUsers()
        {
            var result = _userService.ListAllUsers();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }

        [HttpPost("adduser")]
        public IActionResult AddUser(User user)  
        {
            var result = _userService.Add(user);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);

        }


        [HttpPut("updateuser")]
        public IActionResult UpdateUser(User user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result.Message);
        }

        [HttpGet("getuserbyusername")]
        public IActionResult GetUSerByUserName(string userName)
        {
            var result = _userService.GetUserByName(userName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getuserbyid")]
        public IActionResult GetUserById(int id)
        {
            var result = _userService.GetUserById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpPost("removeuser")]
        public IActionResult RemoveUser(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getusersclaim")]
        public IActionResult GetClaims(User user)
        {
            var result = _userService.GetClaims(user);
            if (result==null)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }


    }
}
