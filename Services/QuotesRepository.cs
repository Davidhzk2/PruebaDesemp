using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaDesemp.Data;
using PruebaDesemp.Models;
using PruebaDesemp.Services;

namespace PruebaDesemp.Extensions
{
    public class QuotesRepository : IQuotesRepository
    {
        public readonly DataContext _context;
        public QuotesRepository(DataContext context){

            _context = context;
        }
        public async  Task<Quote> CreateQuote(Quote quote)
        {
            var result = await _context.Quotes.AddAsync(quote);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Quote>> GetAllQuotes()
        {
            return await _context.Quotes.ToListAsync();
        }

        public async Task<Quote> GetQuoteById(int id)
        {
            return await _context.Quotes.FindAsync(id);
        }

        public async  Task<IEnumerable<Quote>> GetQuoteByVet(int VetId)
        {
            return await _context.Quotes.Where(t => t.VetId == VetId).ToListAsync();
        }

        public async Task<IEnumerable<Quote>> GetQuotesByDate(string date)
        {
            return await _context.Quotes.Where(t => t.Date.ToString().Contains(date)).ToListAsync();
        }

        public async Task<Quote> UpdateQuote(Quote quote)
        {   

            var result = await _context.Quotes.FindAsync(quote.Id);

            if(result != null){
                result.Date = quote.Date;
                result.Description = quote.Description;
                result.PetId = quote.PetId;
                result.VetId = quote.VetId;

                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}