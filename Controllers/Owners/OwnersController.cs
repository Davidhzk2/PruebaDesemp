using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PruebaDesemp.Controllers.Owners
{
    
    public class OwnersController : ControllerBase
    {

        public OwnersController(){
            
        }
        
        [HttpGet]
        [Route ("api/Owners")]
        public async Task<IActionResult> GetAllOwners(){

            return Ok();
        }

        [HttpGet]
        [Route ("api/Owners/{id}")]
        public async Task<IActionResult> GetOwnerById(int id){

            return Ok();
        }
    }
}