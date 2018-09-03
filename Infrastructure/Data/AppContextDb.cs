using ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class AppContextDb : DbContext
    {
        public AppContextDb(DbContextOptions<AppContextDb> options) : base(options)
        {

        }

        public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<AppContextDb>
        {
            AppContextDb IDesignTimeDbContextFactory<AppContextDb>.CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppContextDb>();
                optionsBuilder.UseSqlServer<AppContextDb>("Server = (localdb)\\mssqllocaldb; Database = MyDatabaseName; Trusted_Connection = True; MultipleActiveResultSets = true");

                return new AppContextDb(optionsBuilder.Options);
            }
        }

        public DbSet<Prato> pratos { get; set; }
        public DbSet<Restaurante> restaurantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Prato>().ToTable("prato");
            //modelBuilder.Entity<Restaurante>().ToTable("restaurante");

            modelBuilder.Entity<Restaurante>(ConfigureRestaurante);
            modelBuilder.Entity<Prato>(ConfigurePrato);
        }

        //PROVIDER
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TesteC;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        private void ConfigureRestaurante(EntityTypeBuilder<Restaurante> builder)
        {
            builder.ToTable("restaurante");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Name)
                .IsRequired(true)
                .HasMaxLength(200);

        }

        private void ConfigurePrato(EntityTypeBuilder<Prato> builder)
        {
            builder.ToTable("prato");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Name)
               .IsRequired(true)
               .HasMaxLength(200);

            builder.HasOne(ci => ci.Restaurante)
               .WithMany()
               .HasForeignKey(ci => ci.RestauranteId);

        }
    }
}
