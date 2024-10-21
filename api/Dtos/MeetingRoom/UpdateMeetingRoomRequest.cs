using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.MeetingRoom
{
    public class UpdateMeetingRoomRequest
    {
        public string Details { get; set; } = String.Empty;
        public int NumOfSeats { get; set; }
        public int FloorNum { get; set; }
        public int RoomNum { get; set; }   
    }
}