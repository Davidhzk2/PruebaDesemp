using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Models;
using PruebaDesemp.Services;

namespace PruebaDesemp.Controllers.Owners
{
    
    public class UpdateOwnerController : ControllerBase
    {   
        private readonly IOwnersRepository _ownerRepository;
        public UpdateOwnerController(IOwnersRepository ownerRepository){
            _ownerRepository = ownerRepository;
        }
        
        [HttpPut]
        [Route ("api/owners/{id}")]
        public async Task<IActionResult> CreateOwner(int id,[FromBody] Owner owner){

            if(!ModelState.IsValid)
                return BadRequest("Some required fields are empty!!");
            try
            {   
                if(id != owner.Id)
                    return BadRequest($"The ids doesn't match !! {id} ");

                var searId = await _ownerRepository.GetOwnerById(id);
                if(searId  == null)
                    return BadRequest($"Don't exits a Ownwer with that id {id}");

                var searchEmail = await _ownerRepository.GetOwnerByEmail(owner.Email);

                if(searchEmail != null)
                    return BadRequest("The Email is already Registred!!");


                var result  = await _ownerRepository.UpdateOwner(owner);
                return CreatedAtAction(nameof(OwnersController.GetOwnerById), "Owners", new{id = result.Id}, result);
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: "+ex.Message);
            }
        }
    }
}