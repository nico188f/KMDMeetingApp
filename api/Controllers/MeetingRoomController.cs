using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/MeetingRoom")]
    [ApiController]
    public class MeetingRoomController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public MeetingRoomController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var meetingRooms = _context.MeetingRooms.ToList();

            return Ok(meetingRooms);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id){
            var meetingRoom = _context.MeetingRooms.Find(id);

            if(meetingRoom == null){
                return NotFound();
            }

            return Ok(meetingRoom);
        }
    }
}