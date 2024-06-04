using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesemp.Models;

namespace PruebaDesemp.Services
{
    public interface IPetsRepository
    {
        Task<IEnumerable<Pet>> GetAllPets();
        Task<Pet> GetPetById(int id);
        Task<Pet> CreatePet(Pet pet);
        Task<Pet> UpdatePet(Pet pet);
    }
}