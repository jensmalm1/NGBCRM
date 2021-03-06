﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NGB.Domain;

namespace NGB.Data
{
    public class BeanContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<BeanTypePreferences> BeanTypePreferences { get; set; }
        public DbSet<BeanTypes> BeanTypes { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string your_username = "ngb_user";
            string your_password = "New Gen Bönan är bästa Bönan 4 U!";

            optionsBuilder.UseSqlServer(
                $"Server=tcp:sql-academykaffelab-dev.database.windows.net,1433;Initial Catalog=db-bonan;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeanTypePreferences>().HasKey(x => new { x.BeanTypesId, x.CustomerId });

        }
    }
}
