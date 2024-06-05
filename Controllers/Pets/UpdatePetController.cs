using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Models;
using PruebaDesemp.Services;

namespace PruebaDesemp.Controllers.Owners
{
    
    public class UpdatePetController : ControllerBase
    {

         private readonly IPetsRepository _petsRepository;
        private readonly IOwnersRepository _ownersRepository;
        public UpdatePetController(IPetsRepository petsRepository,IOwnersRepository ownersRepository )
        {

            _petsRepository = petsRepository;
            _ownersRepository = ownersRepository;
        }


        [HttpPut]
        [Route ("api/pets/{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromBody] Pet pet){

            if(!ModelState.IsValid)
                return BadRequest("Some required fields are empty!!");

            try {   
                if(id != pet.Id)
                    return BadRequest($"The ids doesn't match !! {id} ");

                var searchId = await _petsRepository.GetPetById(id);
                if(searchId  == null)
                    return BadRequest($"Don't exits a Pet with that id {id}");

                    var searchOwnerId = await _ownersRepository.GetOwnerById(pet.OwnerId);
                if(searchOwnerId == null)
                    return BadRequest($"There is not a Owner with that id {pet.OwnerId}");

                var result  = await _petsRepository.UpdatePet(pet);
                return Ok(new{status = 200, message= "The pet was updated  successfully !!", result});
            }catch (Exception ex){
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: "+ex.Message);
            }
        }
    }
}