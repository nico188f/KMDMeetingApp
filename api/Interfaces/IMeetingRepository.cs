using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Activity.Meeting;
using api.Models.Activities;

namespace api.Interfaces
{
    public interface IMeetingRepository
    {
        Task<List<Meeting>> GetAllAsync();
        Task<Meeting?> GetByIdAsync(int id);
        Task<Meeting> CreateAsync(Meeting meeting);
        Task<Meeting?> UpdateAsync(int id, UpdateMeetingRequest updateMeetingRequest);
        Task<Meeting?> DeleteAsync(int id);
    }
}