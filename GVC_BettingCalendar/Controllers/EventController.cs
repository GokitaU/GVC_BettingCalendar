using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GVC_BettingCalendar.Models;
using BC.Services.Contracts;
using BC.Web.Mappers;
using NToastNotify;
using BC.Services.CustomExeptions;
using BC.Services.Utils;

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
            _previewModeService = previewModeService
                          ?? throw new BetException(ExceptionMessages.PreviewModeServiceNull);
            _editModeService = editModeService
                          ?? throw new BetException(ExceptionMessages.EditModeServiceContextNull);
            _toast = toast
                          ?? throw new BetException(ExceptionMessages.ToastNull);
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
                id.ValidateIfNull();
                name.ValidateIfNull();
                first.ValidateOdds();
                draw.ValidateOdds();
                second.ValidateOdds();

                var updatedEventDto = await _editModeService.UpdateEvent(id, name, first, draw, second, date);

                var updatedEventVm = updatedEventDto.MapToEventVm();

                _toast.AddSuccessToastMessage("You successfully Update event!");

                return PartialView("_UpdatedRowPartial", updatedEventVm);
            }
            catch (BetException ex)
            {
                _toast.AddErrorToastMessage(ex.Message);
                throw new BetException(ex.Message);
            }
        }

        public async Task<IActionResult> AddEvent(string name, string first, string draw, string second, string date)
        {
            try
            {
                name.ValidateIfNull();
                first.ValidateOdds();
                draw.ValidateOdds();
                second.ValidateOdds();

                var addedEventDto = await _editModeService.AddEvent(name, first, draw, second, date);
                var addedEventVm = addedEventDto.MapToEventVm();
                _toast.AddSuccessToastMessage("You successfully Add new event!");
                return PartialView("_UpdatedRowPartial", addedEventVm);
            }
            catch (BetException ex)
            {
                _toast.AddErrorToastMessage(ex.Message);
                throw new BetException(ex.Message);
            }
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
