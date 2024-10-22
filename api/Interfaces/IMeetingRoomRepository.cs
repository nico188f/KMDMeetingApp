using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.MeetingRoom;
using api.Models;

namespace api.Interfaces
{
    public interface IMeetingRoomRepository
    {
        Task<List<MeetingRoom>> GetAllAsync();
        Task<MeetingRoom?> GetByIdAsync(int id);
        Task<MeetingRoom> CreateAsync(MeetingRoom meetingRoom);
        Task<MeetingRoom?> UpdateAsync(int id, UpdateMeetingRoomRequest updateMeetingRoomRequest);
        Task<MeetingRoom?> DeleteAsync(int id);
    }
}