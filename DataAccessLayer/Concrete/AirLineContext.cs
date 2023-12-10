﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class AirLineContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Adult> Adults { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airport> Airports{ get; set; }
        public DbSet<Child> Childs{ get; set; }
        public DbSet<Flight> Flights{ get; set; }
        public DbSet<Person> Persons { get; set; } // People
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ErensAirlines;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Airport>().HasAlternateKey(k => k.AirportCode); //Unique yaptım

        }
    }
}