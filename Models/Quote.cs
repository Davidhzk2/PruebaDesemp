using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesemp.Models
{
    public class Quote
    {
    public int Id{get; set;}
    [Required]
    public DateTime Date {get; set;}
    [Required]

    public string Description {get; set;}
    [Required]

    public int PetId {get; set;}
    [Required]

    public int VetId {get; set;}
        
    }
}