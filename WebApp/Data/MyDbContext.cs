using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApp.Models;

namespace WebApp.Data
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Antrenor> Antrenors { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Rating> Rating { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rating>().HasKey
                (r => new { r.Id_Antrenor, r.Id_Client });

            modelBuilder.Entity<Rating>().HasOne(r => r.Client)
                .WithMany(c => c.Ratings).HasForeignKey(r => r.Id_Client);

            modelBuilder.Entity<Rating>().HasOne(r => r.Antrenor)
                .WithMany(a => a.Ratings).HasForeignKey(r => r.Id_Antrenor);
        }

    }
}