using System.ComponentModel.DataAnnotations;

namespace BC.Web.Models
{
    public class EventViewModel
    {

        [Required(ErrorMessage = "EventId is required!")]
        public int Id { get; set; }

        [Required(ErrorMessage ="EventName is required!")]
        [MinLength(3, ErrorMessage = "EventName must be between 3 and 100 symbols!"),
            MaxLength(100, ErrorMessage = "EventName must be between 3 and 100 symbols!")]
        public string EventName { get; set; }

        public string OddsForFirstTeam { get; set; }

  
        public string OddsForDraw { get; set; }

        
        public string OddsForSecondTeam { get; set; }   

  
        public string EventStartDate { get; set; }

        public bool IsPassed { get; set; }
    }
}