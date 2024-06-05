using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Models;
using PruebaDesemp.Services;

namespace PruebaDesemp.Controllers.Quotes
{
    
    public class QuotesController : ControllerBase
    {
       private readonly IQuotesRepository _quotesRepository;

       public QuotesController(IQuotesRepository quotesRepository){

            _quotesRepository = quotesRepository;
       }


        [HttpGet]
        [Route("api/quotes")]
        public async Task<IActionResult> GetAllQuotes()
        {

            try{
                var result = await _quotesRepository.GetAllQuotes();
                return Ok(result);
            }
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error HEre!!: " + ex.Message);
            }
        }

       


        [HttpGet]
        [Route("api/quotes/{id}")]
        public async Task<IActionResult> GetQuoteById(int id)
        {

            try{
                var result = await _quotesRepository.GetQuoteById(id);

                if(result == null)
                    return NotFound($"There is not a quote with that id {id}");

                return Ok(result);
            }
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error: " + ex.Message);
            }
        }

         [HttpGet]
        [Route("api/quotes/{date}/date")]
        public async Task<IActionResult> GetQuotesByDate(string date)
        {

            try{
                var result = await _quotesRepository.GetQuotesByDate(date);
                return Ok(result);
            }
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error HEre!!: " + ex.Message);
            }
        }


        [HttpGet]
        [Route("api/quotes/{id}/vets")]
        public async Task<IActionResult> GetQuotesByVet(int id)
        {

            try{
                var result = await _quotesRepository.GetQuoteByVet(id);
                return Ok(result);
            }
            catch (Exception ex){

                return StatusCode(StatusCodes.Status500InternalServerError, "Error HEre!!: " + ex.Message);
            }
        }


    }
}