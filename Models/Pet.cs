using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesemp.Models
{
    public class Pet
    {
    public int Id {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    public string Specie {get; set;}
    [Required]
    public string Race {get; set;}
    [Required]
    public DateTime DateBirth {get; set;}
    [Required]
    public string Photo {get; set;}
    [Required]
    public int OwnerId {get; set;}
    }
}