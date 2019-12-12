using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GVC_BettingCalendar.Models;
using BC.Services.Contracts;
using BC.Web.Mappers;
using BC.Web.Models;

namespace GVC_BettingCalendar.Controllers
{
    public class EventController : Controller
    {
        private readonly IPreviewModeService _previewModeService;
        private readonly IEditModeService _editModeService;

        public EventController(IPreviewModeService previewModeService,
                               IEditModeService editModeService)
        {
            _previewModeService = previewModeService;
            _editModeService = editModeService;
        }

        [HttpGet]
        public async Task<IActionResult> TablePreviewMode()
        {
            var tenEventsDtos = await _previewModeService.GetTenEventsAsync();

            var tenEventsVm = tenEventsDtos.Select(e => e.MapToEventVm());

            return PartialView("_PreviewModePartial", tenEventsVm);
        }

        [HttpGet]
        public async Task<IActionResult> TableEditMode()
        {
            var tenEventsDtos = await _previewModeService.GetTenEventsAsync();

            var tenEventsVm = tenEventsDtos.Select(e => e.MapToEventVm()).ToList();

            return PartialView("_EditModePartial", tenEventsVm);
        }

        public async Task<IActionResult> UpdateEvent(int id, string name, string first, string draw, string second, string date)
        {
            var updatedEventDto = await _editModeService.UpdateEvent(id, name, first, draw, second, date);

            var updatedEventVm = updatedEventDto.MapToEventVm();

            return PartialView("_UpdatedRowPartial",updatedEventVm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
