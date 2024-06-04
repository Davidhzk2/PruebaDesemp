using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesemp.Models;

namespace PruebaDesemp.Services
{
    public interface IQuotesRepository
    {
        Task<IEnumerable<Quote>> GetAllQuotes();
        Task<Quote> GetQuoteById(int id);
        Task<Quote> CreateQuote(Quote quote);
        Task<Quote> UpdateQuote(Quote quote);
    }
}