using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesemp.Models
{
    public class Pet
    {
    public int Id {get; set;}
    public string Name {get; set;}
    public string Specie {get; set;}
    public string Race {get; set;}
    public DateOnly DateBirth {get; set;}
    public string Photo {get; set;}
    public int OwnerId {get; set;}
    }
}