using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagerChain.Domain;

public class Travel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Required]
    public Vehicle Vehicle { get; set; }

    [Required]
    public long ZoneId { get; set; }

    public DateTime Date { get; set; }

    public ICollection<Order> Orders { get; set; }
}
