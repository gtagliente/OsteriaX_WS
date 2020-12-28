using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace modisAPI.Models
{
    public class OsteriaContext : DbContext

    {
        public OsteriaContext(DbContextOptions<OsteriaContext> options):base(options)
        {

        }

        public DbSet<Dish> Dishes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Dish>()
                .HasKey(d => new { d.Id });
        }

    }

}
