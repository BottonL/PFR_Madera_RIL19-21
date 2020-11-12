using maderaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace maderaAPI
{
    public class MaderaContext : DbContext
    {
        public MaderaContext(DbContextOptions<MaderaContext> options)
        : base(options)
        {
        }

        public DbSet<Role> Role { get; set; }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
