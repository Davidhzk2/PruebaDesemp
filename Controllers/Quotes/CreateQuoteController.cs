using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Models;
using PruebaDesemp.Services;
using PruebaDesemp.Services.MailerSend;

namespace PruebaDesemp.Controllers.Quotes
{
   
    public class CreateQuoteController : ControllerBase
    {
        private readonly IQuotesRepository _quotesRepository;
        private readonly IEmailService _emailService;
        private readonly IOwnersRepository _ownersRepository;

       public CreateQuoteController(IQuotesRepository quotesRepository, IEmailService emailService, IOwnersRepository ownersRepository){

            _quotesRepository = quotesRepository;
            _ownersRepository = ownersRepository;
            _emailService = emailService;
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
                var email = await _emailService.SendEmail(result, "guffyherrera150@gmail.com");

                return CreatedAtAction(nameof(QuotesController.GetQuoteById), "Quotes", new{id = result.Id}, new{status=201, email,message= "The Quote was created Successfully!",result});
                //return Ok(result);
            }
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error HEre!!: " + ex.Message);
            }
        }
    }
}