using BC.Data;
using BC.DTOs;
using BC.DTOs.Mappers;
using BC.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BC.Services
{
    public class PreviewModeService : IPreviewModeService
    {
        private readonly BettingContext _context;

        public PreviewModeService(BettingContext context)
        {
            _context = context ?? throw new ArgumentNullException();
        }
        public async Task<ICollection<EventDTO>> GetTenEventsAsync()
        {
            //make pagination
            var events = await _context.Events
                                       .Select(e => e.MapToEventDTO())
                                       .ToListAsync();
            return events;
        }
    }
}
