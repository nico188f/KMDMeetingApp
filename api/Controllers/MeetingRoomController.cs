using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.MeetingRoom;
using api.Mappers;
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

        [HttpPost]
        public IActionResult Create([FromBody] CreateMeetingRoomRequest createMeetingRoomRequest) {
            var meetingRoom = createMeetingRoomRequest.ToMeetingRoom();

            _context.MeetingRooms.Add(meetingRoom);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = meetingRoom.Id }, meetingRoom);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateMeetingRoomRequest updateMeetingRoomRequest) {
            var meetingRoom = _context.MeetingRooms.Find(id);

            if(meetingRoom == null){
                return NotFound();
            }

            // Update the meeting room with the new values
            _context.Entry(meetingRoom).CurrentValues.SetValues(updateMeetingRoomRequest);
            _context.SaveChanges();

            return Ok(meetingRoom);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id){
            var meetingRoom = _context.MeetingRooms.Find(id);

            if(meetingRoom == null){
                return NotFound();
            }

            _context.MeetingRooms.Remove(meetingRoom);
            _context.SaveChanges();

            return NoContent();
        }
    }
}