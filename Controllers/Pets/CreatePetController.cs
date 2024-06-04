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
        public CreatePetController(IPetsRepository petsRepository)
        {

            _petsRepository = petsRepository;
        }

        
        [HttpPost]
        [Route ("api/Pets")]
        public async Task<IActionResult> CreatePet([FromBody] Pet pet){

            if(!ModelState.IsValid)
                return BadRequest("Some data is incomplet");


            try
            {   
                var petResult = await _petsRepository.CreatePet(pet);
                return Ok(petResult);
                //return CreatedAtAction(nameof("GetPetById"), "Pets", new {id = petResult.Id} , petResult);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro: "+ex.Message);
                throw;  
            }
        }
    }
}