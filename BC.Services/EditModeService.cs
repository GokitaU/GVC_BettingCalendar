using BC.Data;
using BC.Data.Entities;
using BC.DTOs;
using BC.DTOs.Mappers;
using BC.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Services
{
    public class EditModeService : IEditModeService
    {
        private readonly BettingContext _context;

        public EditModeService(BettingContext context)
        {
            _context = context;
        }
        public async Task<EventDTO> UpdateEvent(int id, string name, string first, string draw, string second, string date)
        {
            //validate all...
            var eventToEdit = await GetEventById(id);
            //var eventTemplate = new EventDTO
            //{
            eventToEdit.EventName = name;
            eventToEdit.OddsForFirstTeam = double.Parse(first);
            eventToEdit.OddsForDraw = double.Parse(draw);
            eventToEdit.OddsForSecondTeam = double.Parse(second);
            //eventToEdit.EventStartDate = DateTime.Parse(date);
            //};

            //_context.Entry(eventToEdit).CurrentValues.SetValues(eventTemplate);
            await _context.SaveChangesAsync();

            var updatedEventDto = eventToEdit.MapToEventDTO();

            return updatedEventDto;
        }


        public async Task<EventDTO> AddEvent(string name, string first, string draw, string second, string date)
        {
            //validate all...
            var eventCtx = new Event
            {
                EventName = name,
                OddsForFirstTeam = double.Parse(first),
                OddsForDraw = double.Parse(draw),
                OddsForSecondTeam = double.Parse(second),
            };

            _context.Events.Add(eventCtx);

            await _context.SaveChangesAsync();

            var addedEventDto = eventCtx.MapToEventDTO();

            return addedEventDto;
        }


        public async Task<string> DeleteEvent(int id)
        {
            var eventToBeDeleted = await GetEventById(id);
            eventToBeDeleted.IsDeleted = DateTime.Now;
            await _context.SaveChangesAsync();
            return eventToBeDeleted.EventName;
        }


        private async Task<Event> GetEventById(int id)
        {
            //validate
            var eventCtx = await _context.Events.FindAsync(id);
            return eventCtx;
        }
    }
}
