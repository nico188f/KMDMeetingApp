using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Activity.Meeting;
using api.Models.Activities;

namespace api.Mappers
{
    public static class MeetingMapper
    {
        public static Meeting ToMeeting(this CreateMeetingRequest createMeetingRequest) {
            return new Meeting {
                IsOnline = createMeetingRequest.IsOnline,
                StartTime = createMeetingRequest.StartTime,
                DurationMinutes = createMeetingRequest.DurationMinutes,
                Topic = createMeetingRequest.Topic,
                MeetingRoomId = createMeetingRequest.MeetingRoomId
            };
        }
    }
}