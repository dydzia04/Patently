using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patently.Data;

namespace Patently.Models
{
  public class SeedData
  {
    public static void Initalize(IServiceProvider serviceProvider)
    {
      Creator[] creators =
      {
        new Creator( 1, "Jan", "Kowalski" ),
        new Creator( 2, "Adam", "Brzyski" ),
        new Creator( 3, "Marcin", "Smok" )
      };
      using (var context = new MvcCreatorContext( serviceProvider.GetRequiredService<DbContextOptions<MvcCreatorContext>>() ) )
      {
        if (context.Creator.Any())
        {
          return;
        }

        context.Creator.AddRange(creators);
        context.SaveChanges();
      }

      using (var context = new MvcItemContext( serviceProvider.GetRequiredService<DbContextOptions<MvcItemContext>>() ) )
      {
        if (context.Items.Any())
        {
          return;
        }

        context.Items.AddRange(
          new Item
          {
            Creator = new Creator(),
            DateWhenAdded = DateTime.Now.ToString("d"),
            ID = 1,
            Name = "Coś"
          },

          new Item
          {
            Creator = new Creator(),
            DateWhenAdded = DateTime.Now.ToString("d"),
            ID = 2,
            Name = "Cokolwiek"
          },

          new Item
          {
            Creator = new Creator(),
            DateWhenAdded = DateTime.Now.ToString("d"),
            ID = 3,
            Name = "Coś innego"
          }
        );
        context.SaveChanges();
      }
    }
  }
}
