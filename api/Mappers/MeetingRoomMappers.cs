using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.MeetingRoom;
using api.Models;

namespace api.Mappers
{
    public static class MeetingRoomMappers
    {
        public static MeetingRoom ToMeetingRoom(this CreateMeetingRoomRequest createMeetingRoomRequest)
        {
            return new MeetingRoom
            {
                Details = createMeetingRoomRequest.Details,
                NumOfSeats = createMeetingRoomRequest.NumOfSeats,
                FloorNum = createMeetingRoomRequest.FloorNum,
                RoomNum = createMeetingRoomRequest.RoomNum
            };
        }
    }
}