using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesemp.Models
{
    public class Quote
    {
    public int Id{get; set;}
    public DateTime Date {get; set;}
    public string Description {get; set;}
    public int PetId {get; set;}
    public int VetId {get; set;}
        
    }
}