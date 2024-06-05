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

        public async  Task<IEnumerable<Pet>> GetPetsByBirthDate(string date)
        {
             return  await _context.Pets.Where(t=> t.DateBirth.ToString().Contains(date)).ToListAsync();
        }

        public async  Task<IEnumerable<Pet>> GetPetsByOwner(int OwnerId)
        {
            return  await _context.Pets.Where(t=> t.OwnerId == OwnerId).ToListAsync();
        }

        public async  Task<Pet> UpdatePet(Pet pet)
        {
            var result = await _context.Pets.FindAsync(pet.Id);

            if(result != null){

                result.Name = pet.Name;
                result.Specie = pet.Specie;
                result.Race = pet.Race;
                result.DateBirth = pet.DateBirth;
                result.Photo = pet.Photo;
                result.OwnerId = pet.OwnerId;

                await _context.SaveChangesAsync();
                return result;
            }
                return null;
        }
    }
}