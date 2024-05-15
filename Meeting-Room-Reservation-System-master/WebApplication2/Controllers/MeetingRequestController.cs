using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingRequestController : Controller
    {   
            private readonly IMeetingRequestService _meetingRequestService;

        public class MeetingRequestParameters
        {
            public MeetingRequest Request1 { get; set; }
            public MeetingRequest Request2 { get; set; }
        }
        public MeetingRequestController(IMeetingRequestService meetingRequestService)
            {
                _meetingRequestService = meetingRequestService;
           

            }

            [HttpGet]
      /*  public IActionResult GetAllMeetingRequests([FromBody] MeetingRequestParameters parameters)
        {
            var result = _meetingRequestService.ShowMeetingRequest(parameters);
            if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result.Message);
            }*/

            [HttpGet("{id}")]
            public IActionResult GetMeetingRequestById(int id)
            {
                var result = _meetingRequestService.GetById(id);
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                return BadRequest(result.Message);
            }

        [HttpPost("createmeetingrequest")]
        public IActionResult CreateMeetingRequest(MeetingRequest meetingRequest)
        {
            var result = _meetingRequestService.CreateMeetingRequest(meetingRequest);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
            public IActionResult UpdateMeetingRequest(int id, MeetingRequest meetingRequest)
            {
                meetingRequest.MeetingRequestId = id;
                var result = _meetingRequestService.Update(meetingRequest);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteMeetingRequest(int id)
            {
                var result = _meetingRequestService.Delete(id);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }

      
    }
    }
