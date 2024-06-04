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
        public UpdatePetController(IPetsRepository petsRepository)
        {

            _petsRepository = petsRepository;
        }

        [HttpPut]
        [Route ("api/Pets/{id}")]
        public async Task<IActionResult> UpdatePet(int id, [FromBody] Pet pet){

            if(!ModelState.IsValid)
                return BadRequest("Some required fields are empty!!");
            try
            {   
                if(id != pet.Id)
                    return BadRequest($"The ids doesn´t match !! {id} ");

                var searchId = await _petsRepository.GetPetById(id);
                if(searchId  == null)
                    return BadRequest($"Don´t exits a Pet with that id {id}");

            

                var result  = await _petsRepository.UpdatePet(pet);
                //return CreatedAtAction(nameof(OwnersController.GetOwnerById), "Owners", new{id = result.Id}, result);
                return Ok(new{status = 200, message= "The pet was updated  successfully !!", result});
            }
            catch (Exception ex)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: "+ex.Message);
            }
        }
    }
}