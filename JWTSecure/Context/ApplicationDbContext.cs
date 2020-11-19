using JWTSecure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTSecure.Context
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
             
        }

        public DbSet<AppUser> TbUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ELIEZER\\SQLEXPRESS;Database=JWTAuthentication;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.ToTable("JWT_USER");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                .HasMaxLength(40)
                .IsRequired(true)
                .HasColumnName("USER_ID");

                entity.Property(e => e.UserName)
                .HasMaxLength(25)
                .IsRequired(true)
                .HasColumnName("USER_NAME");

                entity.Property(e => e.EmailAdress)
                .HasMaxLength(50)
                .IsRequired(true)
                .HasColumnName("USER_EMAIL");

                entity.Property(e => e.Password)
                .HasMaxLength(maxLength: 500)
                .IsRequired(true)
                .HasColumnName("USER_PASSWORD");
            });
        }
    }
}
