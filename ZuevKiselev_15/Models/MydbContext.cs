using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ZuevKiselev_15.Models;

public partial class MydbContext : DbContext
{
    public MydbContext()
    {
    }

    public MydbContext(DbContextOptions<MydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Airplane> Airplanes { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ApplicationFlightList> ApplicationFlightLists { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<FlightAttendant> FlightAttendants { get; set; }

    public virtual DbSet<FlightPlan> FlightPlans { get; set; }

    public virtual DbSet<Passanger> Passangers { get; set; }

    public virtual DbSet<Pilot> Pilots { get; set; }

    public virtual DbSet<Representative> Representatives { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;user=root;database=mydb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb3_general_ci")
            .HasCharSet("utf8mb3");

        modelBuilder.Entity<Airplane>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Location).HasMaxLength(45);
            entity.Property(e => e.Model).HasMaxLength(45);
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ClientsId, "fk_Applications_Clients1_idx");

            entity.HasIndex(e => e.RepresentativesId, "fk_Applications_Representatives1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Destination).HasMaxLength(45);
            entity.Property(e => e.PlaceOfDeparture).HasMaxLength(45);

            entity.HasOne(d => d.Clients).WithMany(p => p.Applications)
                .HasForeignKey(d => d.ClientsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Applications_Clients1");

            entity.HasOne(d => d.Representatives).WithMany(p => p.Applications)
                .HasForeignKey(d => d.RepresentativesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Applications_Representatives1");
        });

        modelBuilder.Entity<ApplicationFlightList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ApplicationsId, "fk_ApplicationFlightLists_Applications1_idx");

            entity.HasIndex(e => e.FlightsId, "fk_ApplicationFlightLists_Flights1_idx");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Applications).WithMany(p => p.ApplicationFlightLists)
                .HasForeignKey(d => d.ApplicationsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ApplicationFlightLists_Applications1");

            entity.HasOne(d => d.Flights).WithMany(p => p.ApplicationFlightLists)
                .HasForeignKey(d => d.FlightsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ApplicationFlightLists_Flights1");
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Cargo");

            entity.HasIndex(e => e.ApplicationId, "fk_Cargo_Applications1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Number).HasMaxLength(45);

            entity.HasOne(d => d.Application).WithMany(p => p.Cargos)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cargo_Applications1");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(225);
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.AirplanesId, "fk_Flights_Airplanes1_idx");

            entity.HasIndex(e => e.FlightAttendantsId, "fk_Flights_FlightAttendants1_idx");

            entity.HasIndex(e => e.PilotsId, "fk_Flights_Pilots1_idx");

            entity.HasIndex(e => e.RepresentativesId, "fk_Flights_Representatives1_idx");

            entity.HasIndex(e => e.RoutesId, "fk_Flights_Routes1_idx");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Airplanes).WithMany(p => p.Flights)
                .HasForeignKey(d => d.AirplanesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Flights_Airplanes1");

            entity.HasOne(d => d.FlightAttendants).WithMany(p => p.Flights)
                .HasForeignKey(d => d.FlightAttendantsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Flights_FlightAttendants1");

            entity.HasOne(d => d.Pilots).WithMany(p => p.Flights)
                .HasForeignKey(d => d.PilotsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Flights_Pilots1");

            entity.HasOne(d => d.Representatives).WithMany(p => p.Flights)
                .HasForeignKey(d => d.RepresentativesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Flights_Representatives1");

            entity.HasOne(d => d.Routes).WithMany(p => p.Flights)
                .HasForeignKey(d => d.RoutesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Flights_Routes1");
        });

        modelBuilder.Entity<FlightAttendant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(225);
        });

        modelBuilder.Entity<FlightPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.RoutesId, "fk_FlightPlans_Routes1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AlternateAirfield).HasMaxLength(45);
            entity.Property(e => e.ArrivalTime).HasMaxLength(45);
            entity.Property(e => e.DepartureAirfield).HasMaxLength(45);
            entity.Property(e => e.DepartureTime)
                .HasMaxLength(45)
                .HasColumnName("Departure time");
            entity.Property(e => e.DestinationAirfield).HasMaxLength(45);
            entity.Property(e => e.FlightDuration).HasMaxLength(45);

            entity.HasOne(d => d.Routes).WithMany(p => p.FlightPlans)
                .HasForeignKey(d => d.RoutesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_FlightPlans_Routes1");
        });

        modelBuilder.Entity<Passanger>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ApplicationsId, "fk_Passangers_Applications1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(225);

            entity.HasOne(d => d.Applications).WithMany(p => p.Passangers)
                .HasForeignKey(d => d.ApplicationsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Passangers_Applications1");
        });

        modelBuilder.Entity<Pilot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Adress).HasMaxLength(45);
            entity.Property(e => e.Name).HasMaxLength(225);
        });

        modelBuilder.Entity<Representative>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(225);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.TelephoneNumber).HasMaxLength(11);
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.RouteType).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
