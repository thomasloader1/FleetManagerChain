using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FleetManagerChain.Domain.Enums;

namespace FleetManagerChain.Domain
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(20)]
        public string Code { get; set; }

        public int? Size { get; set; }

        public int? Weight { get; set; }

        public DateTime Date { get; set; }

        public double? Distance { get; set; }

        public double? DistanceWithTraffic { get; set; }

        public double? TimeWithTraffic { get; set; }

        [Required]
        public State State { get; set; }  // El enum "Estado" se define abajo

        [ForeignKey("TravelId")]
        public Travel Travel { get; set; }    // Relación Many-to-One con Viaje

        [ForeignKey("ZoneId")]
        public Zone Zone { get; set; } 

    }
}
