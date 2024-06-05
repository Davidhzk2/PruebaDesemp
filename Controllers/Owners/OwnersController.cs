using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Services;

namespace PruebaDesemp.Controllers.Owners
{

    public class OwnersController : ControllerBase
    {

        private readonly IOwnersRepository _ownerRepository;
        public OwnersController(IOwnersRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        [Route("api/owners")]
        public async Task<IActionResult> GetAllOwners()
        {

            try{
                var result = await _ownerRepository.GetAllOwners();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("api/owners/{id}")]
        public async Task<IActionResult> GetOwnerById(int id)
        {

            try{
                var result = await _ownerRepository.GetOwnerById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + ex.Message);
            }
        }
    }
}