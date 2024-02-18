using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Performer_Concert>().HasKey(ac => new 
            {
                ac.PerformerId, 
                ac.ConcertId 
            });

            modelBuilder.Entity<Performer_Concert>().HasOne(ac => ac.Concert).WithMany(c => c.Performers_Concerts).HasForeignKey(ac => ac.ConcertId); 
            modelBuilder.Entity<Performer_Concert>().HasOne(ac => ac.Performer).WithMany(a => a.Performers_Concerts).HasForeignKey(ac => ac.PerformerId); 

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Performer> Performers { get; set; }
        
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<Performer_Concert> Performers_Concerts { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Person> Persons { get; set; }


        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}