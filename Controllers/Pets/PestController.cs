using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PruebaDesemp.Controllers.Owners
{
    
    public class PetsController : ControllerBase
    {

        public PetsController(){
            
        }
        
        [HttpGet]
        [Route ("api/Pets")]
        public async Task<IActionResult> GetAllPets(){

            return Ok();
        }

        [HttpGet]
        [Route ("api/Pets/{id}")]
        public async Task<IActionResult> GetPetById(int id){

            return Ok();
        }
    }
}