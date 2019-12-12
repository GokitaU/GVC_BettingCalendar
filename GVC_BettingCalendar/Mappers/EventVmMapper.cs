using System;
using System.Globalization;
using BC.DTOs;
using BC.Web.Models;

namespace BC.Web.Mappers
{
    public static class EventVmMapper
    {

        public static EventViewModel MapToEventVm(this EventDTO eventDto)
        {
            var eventVm = new EventViewModel();

            eventVm.Id = eventDto.Id;
            eventVm.EventName = eventDto.EventName;
            eventVm.OddsForFirstTeam = $"{eventDto.OddsForFirstTeam:N2}";
            eventVm.OddsForDraw = $"{eventDto.OddsForDraw:N2}";
            eventVm.OddsForSecondTeam = $"{eventDto.OddsForSecondTeam:N2}";
            eventVm.EventStartDate =
                eventDto.EventStartDate.ToString("dd/MM/yyyy HH:mm", DateTimeFormatInfo.InvariantInfo);

            if (eventDto.EventStartDate < DateTime.Now)
                eventVm.IsPassed = true;
            else
                eventVm.IsPassed = false;

            return eventVm;
        }
    }
}