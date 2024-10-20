using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class MeetingRoom
    {
        public int Id { get; set; }
        public string Details { get; set; } = String.Empty;
        public int NumOfSeats { get; set; }
        public int FloorNum { get; set; }
        public int RoomNum { get; set; }
        public List<Activity> Activities { get; set; } = new List<Activity>();
    }
}