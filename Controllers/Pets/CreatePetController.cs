using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PruebaDesemp.Controllers.Owners
{
    
    public class CreatePetController : ControllerBase
    {
        [HttpPost]
        [Route ("api/Pets")]
        public async Task<IActionResult> CreatePet(){

            return Ok();
        }
    }
}