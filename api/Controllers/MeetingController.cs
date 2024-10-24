using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Activity.Meeting;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/meeting")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMeetingRepository _meetingRepo;
        public MeetingController(ApplicationDBContext context, IMeetingRepository meetingRepo)
        {
            _context = context;
            _meetingRepo = meetingRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var meetings = await _meetingRepo.GetAllAsync();

            return Ok(meetings);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var meeting = await _meetingRepo.GetByIdAsync(id);

            if(meeting == null){
                return NotFound();
            }

            return Ok(meeting);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMeetingRequest createMeetingRequest) {
            var newMeeting = await _meetingRepo.CreateAsync(createMeetingRequest.ToMeeting());

            return CreatedAtAction(nameof(GetById), new { id = newMeeting.Id }, newMeeting);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateMeetingRequest updateMeetingRequest){
            var updatedMeeting = await _meetingRepo.UpdateAsync(id, updateMeetingRequest);

            if(updatedMeeting == null){
                return NotFound();
            }

            return Ok(updatedMeeting);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var deletedMeeting = await _meetingRepo.DeleteAsync(id);

            if(deletedMeeting == null){
                return NotFound();
            }

            return NoContent();
        }
    }
}