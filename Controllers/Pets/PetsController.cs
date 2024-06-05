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
        [Route("api/pets")]
        public async Task<IActionResult> GetAllPets()
        {
            try{
                var pets = await _petsRepository.GetAllPets();
                return Ok(pets);
            }
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + ex.Message);
            }

        }

        [HttpGet]
        [Route("api/pets/{id}")]
        public async Task<IActionResult> GetPetById(int id)
        {
            try {
                var pet = await _petsRepository.GetPetById(id);
                if(pet == null)
                return BadRequest($"There is not a pet with that Id {id}");

                return Ok(pet);
            }
            catch (Exception ex) {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + ex.Message);
            }

        }


        [HttpGet]
        [Route("api/pets/{id}/owner")]
        public async Task<IActionResult> GetPetsByOwner(int id)
        {
            try{
                var pets = await _petsRepository.GetPetsByOwner(id);
                return Ok(pets);
            }
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + ex.Message);
            }

        }

        [HttpGet]
        [Route("api/pets/{date}/birthdate")]
        public async Task<IActionResult> GetPetsByBirthDate(string date)
        {
            try{
                var pets = await _petsRepository.GetPetsByBirthDate(date);
                return Ok(pets);
            }
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + ex.Message);
            }

        }
    }
}