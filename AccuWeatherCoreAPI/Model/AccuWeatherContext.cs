using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccuWeatherCoreAPI.Model
{
    public partial class AccuWeatherContext : DbContext
    {
        public AccuWeatherContext()
        {
        }
      
        public AccuWeatherContext(DbContextOptions<AccuWeatherContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CityName> CityName { get; set; }
        public virtual DbSet<CurrentWeatherData> CurrentWeatherData { get; set; }
        public virtual DbSet<WeatherTypes> WeatherTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().EnableDetailedErrors();
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<CityName>(entity =>
            {
                entity.Property(e => e.CityNameId).HasColumnName("CityNameID");

                entity.Property(e => e.CityName1)
                    .IsRequired()
                    .HasColumnName("CityName")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CurrentWeatherData>(entity =>
            {
                entity.HasKey(e => e.CurrentWeatherId);

                entity.Property(e => e.CurrentWeatherId).HasColumnName("CurrentWeatherID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WeatherTypeId).HasColumnName("WeatherTypeID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CurrentWeatherData)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrentWeatherData_CityName");

                entity.HasOne(d => d.WeatherType)
                    .WithMany(p => p.CurrentWeatherData)
                    .HasForeignKey(d => d.WeatherTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CurrentWeatherData_WeatherTypes");
            });

            modelBuilder.Entity<WeatherTypes>(entity =>
            {
                entity.HasKey(e => e.WeatherTypeId);

                entity.Property(e => e.WeatherTypeId).HasColumnName("WeatherTypeID");

                entity.Property(e => e.WeatherTypeName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
