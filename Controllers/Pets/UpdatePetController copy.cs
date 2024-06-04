using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PruebaDesemp.Controllers.Owners
{
    
    public class UpdatePetController : ControllerBase
    {
        [HttpPut]
        [Route ("api/Pest")]
        public async Task<IActionResult> UpdatePet(){

            return Ok();
        }
    }
}