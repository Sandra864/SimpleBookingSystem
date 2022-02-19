using BookingSystemBackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication5;

namespace BookingSystemBackEnd.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne<Resources>(r => r.Resource)
                .WithMany(b => b.Booking)
                .HasForeignKey(r => r.ResourceId);
        }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Booking> Booking { get; set; }

    }
}
