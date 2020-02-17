using Microsoft.EntityFrameworkCore;
using Patently.Models;

namespace Patently.Data
{
    public class MvcItemContext : DbContext
    {
        public MvcItemContext(DbContextOptions<MvcItemContext> options) : base(options){}

        public DbSet<Item> Items { get; set; }
    }
}
