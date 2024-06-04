using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [Route ("api/Pest")]
        public async Task<IActionResult> UpdatePet(){

            try
            {
                var pets = await _petsRepository.GetAllPets();
                return Ok(pets);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + ex.Message);
            }
        }
    }
}