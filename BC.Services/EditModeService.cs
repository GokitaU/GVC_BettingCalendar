﻿using BC.Data;
using BC.Data.Entities;
using BC.DTOs;
using BC.DTOs.Mappers;
using BC.Services.Contracts;
using BC.Services.CustomExeptions;
using BC.Services.Utils;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace BC.Services
{
    public class EditModeService : IEditModeService
    {
        private readonly BettingContext _context;

        public EditModeService(BettingContext context)
        {
            _context = context ?? throw new BetException(ExceptionMessages.ContextNull);
        }
        public async Task<EventDTO> UpdateEvent(int id, string name, string first, string draw, string second, string date)
        {
            try
            {
                var eventToEdit = await GetEventById(id);

                eventToEdit.EventName = name;
                eventToEdit.OddsForFirstTeam = double.Parse(first);
                eventToEdit.OddsForDraw = double.Parse(draw);
                eventToEdit.OddsForSecondTeam = double.Parse(second);

                CultureInfo culture = new CultureInfo("en-US");
                DateTime tempDate = Convert.ToDateTime(date, culture);
                eventToEdit.EventStartDate = tempDate;

                await _context.SaveChangesAsync();

                var updatedEventDto = eventToEdit.MapToEventDTO();

                return updatedEventDto;
            }
            catch (Exception)
            {
                throw new BetException(ExceptionMessages.InvalidModelState);
            }
        }


        public async Task<EventDTO> AddEvent(string name, string first, string draw, string second, string date)
        {
            try
            {
                CultureInfo culture = new CultureInfo("en-US");
                DateTime tempDate = Convert.ToDateTime(date, culture);

                var oddsFirst = double.Parse(first);
                var oddsDraw = double.Parse(draw);
                var oddsSec = double.Parse(second);

                var eventCtx = new Event
                {
                    EventName = name,
                    OddsForFirstTeam = oddsFirst,
                    OddsForDraw = oddsDraw,
                    OddsForSecondTeam = oddsSec,
                    EventStartDate = tempDate
                };

                _context.Events.Add(eventCtx);

                await _context.SaveChangesAsync();

                var addedEventDto = eventCtx.MapToEventDTO();

                return addedEventDto;
            }
            catch (Exception)
            {
                throw new BetException(ExceptionMessages.InvalidModelState);
            }
        }

        public async Task<string> DeleteEvent(int id)
        {
            try
            {
                id.ValidateIfNull();
                var eventToBeDeleted = await GetEventById(id);
                eventToBeDeleted.IsDeleted = DateTime.Now;
                await _context.SaveChangesAsync();
                return eventToBeDeleted.EventName;
            }
            catch (BetException ex)
            {
                throw new BetException(ExceptionMessages.InvalidId);
            }
        }

        private async Task<Event> GetEventById(int id)
        {
            try
            {
                id.ValidateIfNull();
                var eventCtx = await _context.Events.FindAsync(id);
                return eventCtx;
            }
            catch (BetException ex)
            {
                throw new BetException(ExceptionMessages.InvalidId);
            }
        }
    }
}
