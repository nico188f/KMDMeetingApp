using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Activity.Meeting;
using api.Interfaces;
using api.Models.Activities;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly ApplicationDBContext _context;
        public MeetingRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Meeting>> GetAllAsync()
        {
            return await _context.Meetings.ToListAsync();
        }

        public async Task<Meeting?> GetByIdAsync(int id)
        {
            return await _context.Meetings.FindAsync(id);
        }
        
        public async Task<Meeting> CreateAsync(Meeting meeting) {
            await _context.Meetings.AddAsync(meeting);
            await _context.SaveChangesAsync();
            return meeting;
        }

        public async Task<Meeting?> UpdateAsync(int id, UpdateMeetingRequest updateMeetingRequest)
        {
            var meeting = await _context.Meetings.FindAsync(id);

            if(meeting == null){
                return null;
            }

            // Update the meeting with the new values
            _context.Entry(meeting).CurrentValues.SetValues(updateMeetingRequest);
            
            await _context.SaveChangesAsync();

            return meeting;
        }

        public async Task<Meeting?> DeleteAsync(int id)
        {
            var meeting = _context.Meetings.Find(id);

            if(meeting == null){
                return null;
            }

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
            return meeting;
        }
    }
}