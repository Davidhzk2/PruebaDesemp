using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PruebaDesemp.Models;

namespace PruebaDesemp.Services
{
    public interface IVetsRepository
    {
        Task <IEnumerable<Vet>> GetAllVets();
        Task<Vet> GetVetById(int id);
    }
}