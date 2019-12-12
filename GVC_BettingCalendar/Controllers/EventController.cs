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
using NToastNotify;

namespace GVC_BettingCalendar.Controllers
{
    public class EventController : Controller
    {
        private readonly IPreviewModeService _previewModeService;
        private readonly IEditModeService _editModeService;
        private readonly IToastNotification _toast;

        public EventController(IPreviewModeService previewModeService,
                               IEditModeService editModeService,
                               IToastNotification toast)
        {
            _previewModeService = previewModeService;
            _editModeService = editModeService;
            _toast = toast;
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
            try
            {
                var updatedEventDto = await _editModeService.UpdateEvent(id, name, first, draw, second, date);

                var updatedEventVm = updatedEventDto.MapToEventVm();


                return PartialView("_UpdatedRowPartial", updatedEventVm);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task<IActionResult> AddEvent(string name, string first, string draw, string second, string date)
        {
            //validation
            var addedEventDto = await _editModeService.AddEvent(name, first, draw, second, date);
            var addedEventVm = addedEventDto.MapToEventVm();

            return PartialView("_UpdatedRowPartial", addedEventVm);
        }

        public async Task DeleteEvent(int id)
        {
            //validation
            var deletedEventDto = await _editModeService.DeleteEvent(id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
