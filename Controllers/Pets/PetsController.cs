using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Services;

namespace PruebaDesemp.Controllers.Owners
{

    public class PetsController : ControllerBase
    {
        private readonly IPetsRepository _petsRepository;
        public PetsController(IPetsRepository petsRepository)
        {

            _petsRepository = petsRepository;
        }

        [HttpGet]
        [Route("api/Pets")]
        public async Task<IActionResult> GetAllPets()
        {
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

        [HttpGet]
        [Route("api/Pets/{id}")]
        public async Task<IActionResult> GetPetById(int id)
        {
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