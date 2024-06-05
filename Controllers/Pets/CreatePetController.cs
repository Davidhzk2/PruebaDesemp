using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Models;
using PruebaDesemp.Services;

namespace PruebaDesemp.Controllers.Owners
{
    
    public class CreatePetController : ControllerBase
    {

        private readonly IPetsRepository _petsRepository;
        private readonly IOwnersRepository _ownersRepository;
        public CreatePetController(IPetsRepository petsRepository,IOwnersRepository ownersRepository )
        {

            _petsRepository = petsRepository;
            _ownersRepository = ownersRepository;
        }

        
        [HttpPost]
        [Route ("api/pets")]
        public async Task<IActionResult> CreatePet([FromBody] Pet pet){

            if(!ModelState.IsValid)
                return BadRequest("Some required fields are empty!!");

            try
            {  
                var searchOwnerId = await _ownersRepository.GetOwnerById(pet.OwnerId);
                if(searchOwnerId == null)
                    return BadRequest($"There is not a Owner with that id {pet.OwnerId}");
                 
                var petResult = await _petsRepository.CreatePet(pet);
                return CreatedAtAction(nameof(PetsController.GetPetById), "Pets", new {id = petResult.Id} , new{status=201, message= "The Pet was created successfully!",petResult});
                //return Ok(petResult);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: "+ex.Message);
                throw;  
            }
        }
    }
}