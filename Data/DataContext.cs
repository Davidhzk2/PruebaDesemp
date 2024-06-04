using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebaDesemp.Models;

namespace PruebaDesemp.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext (DbContextOptions<DataContext> options): base(options){}

        public DbSet<Owner> Owners {get;set;}
        public DbSet<Vet> Vets {get; set;}

        public DbSet<Pet> Pets {get; set;}
        public DbSet<Quote> Quotes {get; set;}
    }
}