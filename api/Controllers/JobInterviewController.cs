using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Activity.JobInterview;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/JobInterview")]
    [ApiController]
    public class JobInterviewController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IJobInterviewRepository _jobInterviewRepo;
        public JobInterviewController(ApplicationDBContext context, IJobInterviewRepository jobInterviewRepo)
        {
            _context = context;
            _jobInterviewRepo = jobInterviewRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var jobInterviews = await _jobInterviewRepo.GetAllAsync();

            return Ok(jobInterviews);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id){
            var jobInterview = await _jobInterviewRepo.GetByIdAsync(id);

            if(jobInterview == null){
                return NotFound();
            }

            return Ok(jobInterview);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateJobInterviewRequest createJobInterviewRequest) {
            var newJobInterview = await _jobInterviewRepo.CreateAsync(createJobInterviewRequest.ToJobInterview());

            return CreatedAtAction(nameof(GetById), new { id = newJobInterview.Id }, newJobInterview);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateJobInterviewRequest updateJobInterviewRequest){
            var updatedJobInterview = await _jobInterviewRepo.UpdateAsync(id, updateJobInterviewRequest);

            if(updatedJobInterview == null){
                return NotFound();
            }

            return Ok(updatedJobInterview);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id){
            var deletedJobInterview = await _jobInterviewRepo.DeleteAsync(id);

            if(deletedJobInterview == null){
                return NotFound();
            }

            return Ok(deletedJobInterview);
        }
    }
}