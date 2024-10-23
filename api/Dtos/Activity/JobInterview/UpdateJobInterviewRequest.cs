using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Activity.JobInterview
{
    public class UpdateJobInterviewRequest
    {
        public bool IsOnline { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public string CandidateName { get; set; } = String.Empty;
        public int? MeetingRoomId { get; set; }
    }
}