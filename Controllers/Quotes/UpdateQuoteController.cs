using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Models;
using PruebaDesemp.Services;

namespace PruebaDesemp.Controllers.Quotes
{
   
    public class UpdateQuoteController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;

       public UpdateQuoteController(IQuotesRepository quotesRepository){

            _quotesRepository = quotesRepository;
       }


       [HttpPut]
    [Route("api/quotes/{id}")]
        public async Task<IActionResult> UpdateQuote(int id, [FromBody] Quote quote)
        {   
            if(!ModelState.IsValid)
                return BadRequest("Some required field are empty!!");

            try{

                if(id != quote.Id)
                    return NotFound($"The ids doesn't match !! {id} ");

                var searchId = await _quotesRepository.GetQuoteById(id);

                if(searchId  == null)
                    return NotFound($"Don´t exits a Quote with that id {id}");


                var result = await _quotesRepository.UpdateQuote(quote);

                return Ok(new{status = 200, message= "The quote was updated  successfully !!", result});
            }
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error here!!: " + ex.Message);
            }
        }
    }
}