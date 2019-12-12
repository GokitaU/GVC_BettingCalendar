using BC.Data.Entities;

namespace BC.DTOs.Mappers
{
    public static class EventMapper
    {
        public static EventDTO MapToEventDTO(this Event eventCtx)
        {
            var eventDTO = new EventDTO();

            eventDTO.Id = eventCtx.Id;
            eventDTO.EventName = eventCtx.EventName;
            eventDTO.OddsForFirstTeam = eventCtx.OddsForFirstTeam;
            eventDTO.OddsForDraw = eventCtx.OddsForDraw;
            eventDTO.OddsForSecondTeam = eventCtx.OddsForSecondTeam;
            eventDTO.EventStartDate = eventCtx.EventStartDate;

            return eventDTO;
        }
    }
}
