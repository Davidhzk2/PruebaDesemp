using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Models;
using PruebaDesemp.Services;

namespace PruebaDesemp.Controllers.Owners
{
    
    public class CreateOwnerController : ControllerBase
    {
        private readonly IOwnersRepository _ownerRepository;
        public CreateOwnerController(IOwnersRepository ownerRepository){
            _ownerRepository = ownerRepository;
        }

        [HttpPost]
        [Route ("api/owners")]
        public async Task<IActionResult> CreateOwner([FromBody] Owner owner){

            if(!ModelState.IsValid)
                return BadRequest("Some required fields are empty!!");
            try
            {   

                var searchEmail = await _ownerRepository.GetOwnerByEmail(owner.Email);

                if(searchEmail != null)
                    return BadRequest("The Email is already Registred!!");


                var result  = await _ownerRepository.CreateOwner(owner);
                return CreatedAtAction(nameof(OwnersController.GetOwnerById), "Owners", new{id = result.Id}, new{status=201, message= "The Owner was created successfully!",result});
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: "+ex.Message);
            }
        }
    }
}