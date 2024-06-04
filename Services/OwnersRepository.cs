using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaDesemp.Data;
using PruebaDesemp.Models;

namespace PruebaDesemp.Services
{
    public class OwnersRepository : IOwnersRepository
    {
        public readonly DataContext _context;
        public OwnersRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<Owner> CreateOwner(Owner owner)
        {

            var result = await _context.AddAsync(owner);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async  Task<IEnumerable<Owner>> GetAllOwners()
        {
            return  await _context.Owners.ToListAsync();
        }

        public async  Task<Owner> GetOwnerByEmail(string email)
        {
            return  await _context.Owners.FirstOrDefaultAsync(o => o.Email == email);
        }

        public async  Task<Owner> GetOwnerById(int id)
        {
             return  await _context.Owners.FindAsync(id);
        }

        public async  Task<Owner> UpdateOwner(Owner owner)
        {
            var result = await _context.Owners.FindAsync(owner.Id);

            if(result != null){
                result.Names = owner.Names;
                result.LastNames = owner.LastNames;
                result.Email = owner.Email;
                result.Address = owner.Address;
                result.Phone = owner.Phone;
                
            
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}