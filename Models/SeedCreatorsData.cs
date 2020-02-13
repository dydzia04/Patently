using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patently.Data;

namespace Patently.Models
{
    public class SeedCreatorsData
    {
        public static void Initalize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcCreatorContext( serviceProvider.GetRequiredService<DbContextOptions<MvcCreatorContext>>() ) )
            {
                if (context.Creators.Any())
                {
                    return;
                }
                
                context.Creators.AddRange(
                    new Creator
                    {
                        ID = 1,
                        ItemsCreated = {},
                        Name = "Jan",
                        SecName = "Kowalski"
                    },
                    
                    new Creator
                    {
                        ID = 2,
                        ItemsCreated = {},
                        Name = "Adam",
                        SecName = "Brzyski"
                    },
                    
                    new Creator
                    {
                        ID = 3,
                        ItemsCreated = {},
                        Name = "Marcin",
                        SecName = "Smok"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}