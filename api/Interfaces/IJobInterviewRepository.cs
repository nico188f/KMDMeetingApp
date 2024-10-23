using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Activity.JobInterview;
using api.Models.Activities;

namespace api.Interfaces
{
    public interface IJobInterviewRepository
    {
        Task<List<JobInterview>> GetAllAsync();
        Task<JobInterview?> GetByIdAsync(int id);
        Task<JobInterview> CreateAsync(JobInterview jobInterview);
        Task<JobInterview?> UpdateAsync(int id, UpdateJobInterviewRequest updateJobInterviewRequest);
        Task<JobInterview?> DeleteAsync(int id);
    }
}