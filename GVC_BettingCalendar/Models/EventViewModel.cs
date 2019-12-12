using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //[Column(TypeName = "decimal(18,2)")]
        //[Range(1, 1000, ErrorMessage = "OddsForDraw must be between 1 and 1000")]
        public string OddsForDraw { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        //[Range(1, 1000, ErrorMessage = "OddsForSecondTeam must be between 1 and 1000")]
        public string OddsForSecondTeam { get; set; }   

        //[Required(ErrorMessage = "EventStartDate is required!"), DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public string EventStartDate { get; set; }

        public bool IsPassed { get; set; }

    }
}
