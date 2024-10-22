using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.MeetingRoom;
using api.Interfaces;
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
        private readonly IMeetingRoomRepository _meetingRoomRepo;
        public MeetingRoomController(ApplicationDBContext context, IMeetingRoomRepository meetingRoomRepo)
        {
            _meetingRoomRepo = meetingRoomRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var meetingRooms = await _meetingRoomRepo.GetAllAsync();

            return Ok(meetingRooms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var meetingRoom = await _meetingRoomRepo.GetByIdAsync(id);

            if(meetingRoom == null){
                return NotFound();
            }

            return Ok(meetingRoom);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMeetingRoomRequest createMeetingRoomRequest) {
            var meetingRoom = await _meetingRoomRepo.CreateAsync(createMeetingRoomRequest.ToMeetingRoom());

            return CreatedAtAction(nameof(GetById), new { id = meetingRoom.Id }, meetingRoom);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMeetingRoomRequest updateMeetingRoomRequest) {
            var meetingRoom = await _meetingRoomRepo.UpdateAsync(id, updateMeetingRoomRequest);

            if(meetingRoom == null){
                return NotFound();
            }

            return Ok(meetingRoom);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var meetingRoom = await _meetingRoomRepo.DeleteAsync(id);

            if(meetingRoom == null){
                return NotFound();
            }

            return NoContent();
        }
    }
}