using TruppEx.Models;
using Microsoft.EntityFrameworkCore;

namespace TruppEx.Data
{
    public class TruppContext : DbContext
    {
        public TruppContext(DbContextOptions<TruppContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LifeEvent> LifeEvents { get; set; }
        public DbSet<LifeEventType> LifeEventTypes { get; set; }
    }
}
