using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollisionsDB.Models
{
    public class CollisionDBContext : DbContext 
    {
        public CollisionDBContext(DbContextOptions<CollisionDBContext> options) : base(options)
        {
        }

        public DbSet<Collision> Collisions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
    }
}
