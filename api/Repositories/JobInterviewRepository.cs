using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Activity.JobInterview;
using api.Interfaces;
using api.Models.Activities;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class JobInterviewRepository : IJobInterviewRepository
    {
        private readonly ApplicationDBContext _context;
        public JobInterviewRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<JobInterview>> GetAllAsync()
        {
            return await _context.JobInterviews.Include(c => c.MeetingRoom).ToListAsync();
        }

        public async Task<JobInterview?> GetByIdAsync(int id)
        {
            return await _context.JobInterviews.Include(c => c.MeetingRoom).FirstOrDefaultAsync(i => i.Id == id);
        }
        public async Task<JobInterview> CreateAsync(JobInterview jobInterview)
        {
            await _context.JobInterviews.AddAsync(jobInterview);
            await _context.SaveChangesAsync();
            return jobInterview;
        }
        public async Task<JobInterview?> UpdateAsync(int id, UpdateJobInterviewRequest updateJobInterviewRequest)
        {
            var jobInterview = await _context.JobInterviews.FindAsync(id);

            if(jobInterview == null){
                return null;
            }

            // Update the jobInterview with the new values
            _context.Entry(jobInterview).CurrentValues.SetValues(updateJobInterviewRequest);
            
            await _context.SaveChangesAsync();

            return jobInterview;
        }
        public async Task<JobInterview?> DeleteAsync(int id)
        {
            var jobInterview = _context.JobInterviews.Find(id);

            if(jobInterview == null){
                return null;
            }

            _context.JobInterviews.Remove(jobInterview);
            await _context.SaveChangesAsync();
            
            return jobInterview;
        }
    }
}