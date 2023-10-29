﻿using EeFee.Models;
using Microsoft.EntityFrameworkCore;

namespace EeFee.Data
{
    public class EeFeeContext : DbContext
    {
        public EeFeeContext(DbContextOptions<EeFeeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
