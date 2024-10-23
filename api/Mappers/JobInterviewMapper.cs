using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Activity.JobInterview;
using api.Models.Activities;

namespace api.Mappers
{
    public static class JobInterviewMapper
    {
        public static JobInterview ToJobInterview(this CreateJobInterviewRequest createJobInterviewRequest)
        {
            return new JobInterview
            {
                IsOnline = createJobInterviewRequest.IsOnline,
                StartTime = createJobInterviewRequest.StartTime,
                DurationMinutes = createJobInterviewRequest.DurationMinutes,
                CandidateName = createJobInterviewRequest.CandidateName,
                MeetingRoomId = createJobInterviewRequest.MeetingRoomId
            };
        }
    }
}