using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PruebaDesemp.Controllers.Owners
{
    
    public class CreateOwnerController : ControllerBase
    {
        [HttpPost]
        [Route ("api/Owners")]
        public async Task<IActionResult> CreateOwner(){

            return Ok();
        }
    }
}