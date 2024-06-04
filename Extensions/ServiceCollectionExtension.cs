using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PruebaDesemp.Extensions
{
    public static class ServiceCollectionExtenxion
    {
        public static void AddRepositories(this IServiceCollection services, Assembly assembly)
        {
            
            var types = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.Name.EndsWith("Repository"))
                .ToList();

            foreach (var type in types)
            {
                
                var interfaceType = type.GetInterface($"I{type.Name}");
                if (interfaceType != null)
                {
                    
                    services.AddScoped(interfaceType, type);
                }
            }
        }
    }
}