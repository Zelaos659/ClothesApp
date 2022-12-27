﻿using LogPassTwo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogPass.Data
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-S0IVJPK;Database=ClothesAppBD;Trusted_Connection=True;Encrypt=False;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-S0IVJPK;Database=ILOVEBDSOMUCH;Trusted_Connection=True;Encrypt=False;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasIndex(p => p.Login)
                .IsUnique();
        }
    }
}
