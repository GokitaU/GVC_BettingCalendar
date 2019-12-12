using BC.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BC.Services.Contracts
{
    public interface IPreviewModeService
    {
        Task<ICollection<EventDTO>> GetTenEventsAsync();
    }
}
