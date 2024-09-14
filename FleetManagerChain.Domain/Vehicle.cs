using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FleetManagerChain.Domain;

public class Vehicle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    [Required]
    [ForeignKey("UserId")]
    public User User { get; set; }
    
    [Required]
    public string ModelName { get; set; }
    
    [Required]
    public string Brand { get; set; }
    
    [Required]
    public string Type { get; set; }
    
    [Required]
    public string Patent { get; set; }
    
    [Required]
    public bool Status { get; set; }
    
    [Required]
    public int Fuel { get; set; }
    
    [Required]
    public int Capacity { get; set; }
    
    [Required]
    public int Resistence { get; set; }
    
    [Required]
    public int MaxKm { get; set; }



}
