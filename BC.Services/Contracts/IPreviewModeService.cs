using System.Threading.Tasks;
using System.Collections.Generic;
using BC.DTOs;

namespace BC.Services.Contracts
{
    public interface IPreviewModeService
    {
        Task<ICollection<EventDTO>> GetTenEventsAsync();
    }
}
