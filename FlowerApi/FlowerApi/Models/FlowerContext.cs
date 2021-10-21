using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerApi.Models
{
    public class FlowerContext:DbContext
    {
        public FlowerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<User>  Users { get; set; }
    }
}
