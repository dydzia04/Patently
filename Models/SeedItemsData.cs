using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patently.Data;

namespace Patently.Models
{
    public class SeedItemsData
    {
        public static void Initalize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcItemContext( serviceProvider.GetRequiredService<DbContextOptions<MvcItemContext>>() ) )
            {
                if (context.Items.Any())
                {
                    return;
                }
                
                context.Items.AddRange(
                    new Item
                    {
                        Creator = {},
                        DateWhenAdded = DateTime.Now,
                        ID = 1,
                        Name = "Coś"
                    },
                    
                    new Item
                    {
                        Creator = {},
                        DateWhenAdded = DateTime.Now,
                        ID = 2,
                        Name = "Cokolwiek"
                    },
                    
                    new Item
                    {
                        Creator = {},
                        DateWhenAdded = DateTime.Now,
                        ID = 3,
                        Name = "Coś innego"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}