using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BC.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 1000)]
        public double OddsForFirstTeam { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 1000)]
        public double OddsForDraw { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(1, 1000)]
        public double OddsForSecondTeam { get; set; }

        [Required]
        public DateTime EventStartDate { get; set; }

    }
}
