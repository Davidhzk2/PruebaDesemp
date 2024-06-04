using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Models;
using PruebaDesemp.Services;

namespace PruebaDesemp.Controllers.Quotes
{
   
    public class CreateQuoteController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;

       public CreateQuoteController(IQuotesRepository quotesRepository){

            _quotesRepository = quotesRepository;
       }


       [HttpPost]
        [Route("api/quotes")]
        public async Task<IActionResult> CreateQuote([FromBody] Quote quote)
        {   
            if(!ModelState.IsValid)
                return BadRequest("Some required field are empty!!");

            try{
                var result = await _quotesRepository.CreateQuote(quote);

                //send email to  the owner !

                return CreatedAtAction(nameof(QuotesController.GetQuoteById), "Quotes", new{id = result.Id}, new{status=201, message= "The Quote was created Successfully!",result});
                //return Ok(result);
            }
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error HEre!!: " + ex.Message);
            }
        }
    }
}