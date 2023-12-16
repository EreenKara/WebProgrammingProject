using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    // Identity kütüphanesini kullandığımız için aşağıdaki context'ten kalıttım.
    public class AirLineContext:IdentityDbContext<AppUser,AppRole,string>
    {
        //public DbSet<Account> Accounts { get; set; }
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
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ErensAirlines;Trusted_Connection=True;MultipleActiveResultSets=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Airport>().HasAlternateKey(k => k.AirportCode); //Unique yaptım
            modelBuilder.Entity<Person>().ToTable("Persons"); // TPT 
            modelBuilder.Entity<Adult>().ToTable("Adults"); // TPT
            modelBuilder.Entity<Child>().ToTable("Childs"); // TPT

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }
            
            
        }
    }
}
