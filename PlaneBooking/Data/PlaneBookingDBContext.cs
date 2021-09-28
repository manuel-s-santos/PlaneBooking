using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.Data;

namespace PlaneBooking.Data
{
    public class PlaneBookingDBContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<TutorAvailability> TutorAvailabilities { get; set; }

        public DbSet<AirplaneBooking> AirplaneBookings { get; set; }

        public PlaneBookingDBContext(DbContextOptions<PlaneBookingDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId);
                entity.Property(e => e.Password).HasMaxLength(250);
                entity.Property(e => e.Email).HasMaxLength(250);
                entity.Property(e => e.Firstname).HasMaxLength(250);
                entity.Property(e => e.Lastname).HasMaxLength(250);

                entity.HasData(new AppUser
                {
                    UserId = 1,
                    Email = "admin@email.com",
                    Password = "admin123",
                    Firstname = "Administrator",
                    Lastname = "",
                    Role = "Admin"
                });

            });

            modelBuilder.Entity<AirplaneBooking>()
                    .HasOne(e => e.Student)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AirplaneBooking>()
                    .HasOne(e => e.Tutor)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
