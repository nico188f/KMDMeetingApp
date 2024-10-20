using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models.Activities
{
    public abstract class Activity
    {
        public int Id { get; set; }
        public bool IsOnline { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationMinutes { get; set; }
        public int? MeetingRoomId { get; set; }
        public MeetingRoom? MeetingRoom { get; set; } 
    }
}