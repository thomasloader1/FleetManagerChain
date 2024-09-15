using System;
using System.Collections.Generic;
using FleetManagerChain.Domain;
using Microsoft.EntityFrameworkCore;

namespace FleetManagerChain.Web.Context;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
   public DbSet<Vehicle> Vehicles { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<User>(modelUser =>
        {

            modelUser.HasKey(col => col.Id);
            // Configuración de las propiedades
            modelUser.Property(col => col.Id).UseIdentityColumn().ValueGeneratedOnAdd(); // El valor se generará al agregarlo
            modelUser.Property(col => col.Username);
            modelUser.Property(col => col.Email);
            modelUser.Property(col => col.Password);
            modelUser.Property(col => col.Role);
            modelUser.Property(col => col.IsActive);
 
        });

       modelBuilder.Entity<Vehicle>(modelVehicle =>
        {

            modelVehicle.HasKey(col => col.Id);
            // Configuración de las propiedades
            modelVehicle.Property(col => col.Id).UseIdentityColumn().ValueGeneratedOnAdd(); // El valor se genera al agregarlo
            modelVehicle.Property(col => col.ModelName);
            modelVehicle.Property(col => col.Brand);
            modelVehicle.Property(col => col.Type);
            modelVehicle.Property(col => col.Patent);
            modelVehicle.Property(col => col.Status);
            modelVehicle.Property(col => col.Fuel);
            modelVehicle.Property(col => col.Capacity);
            modelVehicle.Property(col => col.Resistence);
            modelVehicle.Property(col => col.MaxKm);
            // Relación con la entidad usuario
            modelVehicle.HasOne(v => v.User);

        });

        modelBuilder.Entity<Order>(modelOrder =>
        {
            modelOrder.HasKey(col => col.Id);
            modelOrder.Property(col => col.Id).UseIdentityColumn().ValueGeneratedOnAdd(); // El valor se genera al agregarlo
            // Configuración de propiedades
            modelOrder.Property(col => col.Name);
            modelOrder.Property(col => col.Type);
            modelOrder.Property(col => col.Code);
            modelOrder.Property(col => col.Size);
            modelOrder.Property(col => col.Weight);
            modelOrder.Property(col => col.Date);
            modelOrder.Property(col => col.Distance);
            modelOrder.Property(col => col.DistanceWithTraffic);
            modelOrder.Property(col => col.TimeWithTraffic);
            modelOrder.Property(col => col.State);
            //Relaciones con viaje y zona
            modelOrder.HasOne(o => o.Travel);
            modelOrder.HasOne(o => o.Zone);
        });

        modelBuilder.Entity<Travel>(modelTravel =>
        {
            modelTravel.HasKey(col => col.Id);
            modelTravel.Property(col => col.Id).UseIdentityColumn().ValueGeneratedOnAdd();
            // Configuración de propiedades
            modelTravel.Property(t => t.ZoneId);
            modelTravel.Property(t => t.Date);
            //Relaciones con orden y vehiculo
            modelTravel.HasMany(t => t.Orders);
            modelTravel.HasOne(t => t.Vehicle);
        });

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
