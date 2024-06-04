using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesemp.Models;

namespace PruebaDesemp.Services
{
    public interface IOwnersRepository
    {
         Task<IEnumerable<Owner>> GetAllOwners();
        Task<Owner> GetOwnerById(int id);
        Task<Owner> GetOwnerByEmail(string email);
        Task<Owner> CreateOwner(Owner owner);
        Task<Owner> UpdateOwner(Owner owner);
    }
}