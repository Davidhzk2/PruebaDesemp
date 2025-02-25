using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Services;

namespace PruebaDesemp.Controllers.Vets
{

    public class VetsController : ControllerBase
    {
        private readonly IVetsRepository _vetsRepository;
        public VetsController(IVetsRepository vetsRepository)
        {
            _vetsRepository = vetsRepository;
        }

        [HttpGet]
        [Route("api/vets")]
        public async Task<IActionResult> GetAllVets()
        {

            try{
                var result = await _vetsRepository.GetAllVets();
                return Ok(result);
            }catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/vets/{id}")]
        public async Task<IActionResult> GetVetById(int id)
        {
            try{
                var result = await _vetsRepository.GetVetById(id);
                if(result == null )
                    return BadRequest($"There is not a vet with thar Id {id}");

                return Ok(result);
            }catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + ex.Message);
            }
        }

    }
}