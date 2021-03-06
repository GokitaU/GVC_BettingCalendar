﻿using BC.DTOs;
using System.Threading.Tasks;

namespace BC.Services.Contracts
{
    public interface IEditModeService
    {
        Task<EventDTO> UpdateEvent(int id, string name, string first, string draw, string second, string date);

        Task<string> DeleteEvent(int id);

        Task<EventDTO> AddEvent(string name, string first, string draw, string second, string date);
    }
}
