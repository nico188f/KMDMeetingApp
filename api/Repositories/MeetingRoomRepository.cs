using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.MeetingRoom;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class MeetingRoomRepository : IMeetingRoomRepository
    {
        private readonly ApplicationDBContext _context;
        public MeetingRoomRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        
        public async Task<List<MeetingRoom>> GetAllAsync()
        {
            return await _context.MeetingRooms.ToListAsync();
        }
        public async Task<MeetingRoom?> GetByIdAsync(int id)
        {
            return await _context.MeetingRooms.FindAsync(id);
        }
        public async Task<MeetingRoom> CreateAsync(MeetingRoom meetingRoom)
        {
            await _context.MeetingRooms.AddAsync(meetingRoom);
            await _context.SaveChangesAsync();
            return meetingRoom;
        }


        public async Task<MeetingRoom?> UpdateAsync(int id, UpdateMeetingRoomRequest updateMeetingRoomRequest)
        {
            var meetingRoom = await _context.MeetingRooms.FindAsync(id);

            if(meetingRoom == null){
                return null;
            }

            // Update the meetingRoom with the new values
            _context.Entry(meetingRoom).CurrentValues.SetValues(updateMeetingRoomRequest);
            
            await _context.SaveChangesAsync();

            return meetingRoom;
        }

        public async Task<MeetingRoom?> DeleteAsync(int id)
        {
            var meetingRoom = _context.MeetingRooms.Find(id);

            if(meetingRoom == null){
                return null;
            }

            _context.MeetingRooms.Remove(meetingRoom);
            await _context.SaveChangesAsync();

            return meetingRoom;
        }
    }
}