using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Models
{
    public class BazaarContext : DbContext
    {
        public BazaarContext(DbContextOptions<BazaarContext> options)
            : base(options)
        {

        }

        public DbSet<ProductInfo> ProductInfo { get; set; }

        public DbSet<ProductGroup> ProductGroup { get; set; }

    }
}