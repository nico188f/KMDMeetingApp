using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.MeetingRoom;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll(){
            var meetingRooms = await _context.MeetingRooms.ToListAsync();

            return Ok(meetingRooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var meetingRoom = await _context.MeetingRooms.FindAsync(id);

            if(meetingRoom == null){
                return NotFound();
            }

            return Ok(meetingRoom);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMeetingRoomRequest createMeetingRoomRequest) {
            var meetingRoom = createMeetingRoomRequest.ToMeetingRoom();

            await _context.MeetingRooms.AddAsync(meetingRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = meetingRoom.Id }, meetingRoom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMeetingRoomRequest updateMeetingRoomRequest) {
            var meetingRoom = await _context.MeetingRooms.FindAsync(id);

            if(meetingRoom == null){
                return NotFound();
            }

            // Update the meeting room with the new values
            _context.Entry(meetingRoom).CurrentValues.SetValues(updateMeetingRoomRequest);
            await _context.SaveChangesAsync();

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