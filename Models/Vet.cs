using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaDesemp.Models
{
    public class Vet
    {
        public int Id { get; set; }
        [Required]
        public string Names { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string Phone { get; set; }
    }
}