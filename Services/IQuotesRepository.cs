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
        Task<IEnumerable<Quote>> GetQuotesByDate(string date);
        Task<Quote> GetQuoteById(int id);
        Task<IEnumerable<Quote>> GetQuoteByVet(int VetId);
        Task<Quote> CreateQuote(Quote quote);
        Task<Quote> UpdateQuote(Quote quote);
    }
}