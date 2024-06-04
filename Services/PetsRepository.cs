using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaDesemp.Data;
using PruebaDesemp.Models;

namespace PruebaDesemp.Services
{
    public class PetsRepository : IPetsRepository
    {
        public readonly DataContext _context;
        public PetsRepository(DataContext context){
            _context = context;
        }
        public async Task<Pet> CreatePet(Pet pet)
        {
            
            var result = await _context.AddAsync(pet);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async  Task<IEnumerable<Pet>> GetAllPets()
        {
            return  await _context.Pets.ToListAsync();
        }

        public async Task<Pet> GetPetById(int id)
        {
            return  await _context.Pets.FindAsync(id);
        }

        public async  Task<Pet> UpdatePet(Pet pet)
        {
            var result = await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
    }
}