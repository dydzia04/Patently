using Microsoft.EntityFrameworkCore;
using Patently.Models;

namespace Patently.Data
{

    public class MvcCreatorContext : DbContext
    {
        public MvcCreatorContext(DbContextOptions<MvcCreatorContext> options) : base(options){}

        public DbSet<Creator> Creator { get; set; }
    }
}
