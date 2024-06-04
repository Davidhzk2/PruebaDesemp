using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaDesemp.Data;
using PruebaDesemp.Models;

namespace PruebaDesemp.Services
{
    public class VetsRepository : IVetsRepository
    {
        public readonly DataContext _context;

        public VetsRepository(DataContext context){
            _context = context;
        }

        public async Task<IEnumerable<Vet>> GetAllVets()
        {
            return await _context.Vets.ToListAsync();
        }

        public async  Task<Vet> GetVetById(int id)
        {
            return await _context.Vets.FindAsync(id);
        }
    }
}