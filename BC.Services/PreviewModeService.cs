using BC.Data;
using BC.DTOs;
using BC.DTOs.Mappers;
using BC.Services.Contracts;
using BC.Services.CustomExeptions;
using Microsoft.EntityFrameworkCore;
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
            _context = context ?? throw new BetException(ExceptionMessages.ContextNull);
        }
        public async Task<ICollection<EventDTO>> GetTenEventsAsync()
        {
            //pagination
            var events = await _context.Events
                                       .Where(e=>e.IsDeleted == null)
                                       .Select(e => e.MapToEventDTO())
                                       .ToListAsync();
            return events;
        }
    }
}
