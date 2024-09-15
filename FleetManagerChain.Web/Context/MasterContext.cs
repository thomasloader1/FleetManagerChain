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
            // Relación con la entidad User (Foreign Key)
            modelVehicle.HasOne(v => v.User);
            modelVehicle.Property(col => col.ModelName);
            modelVehicle.Property(col => col.Brand);
            modelVehicle.Property(col => col.Type);
            modelVehicle.Property(col => col.Patent);
            modelVehicle.Property(col => col.Status);
            modelVehicle.Property(col => col.Fuel);
            modelVehicle.Property(col => col.Capacity);
            modelVehicle.Property(col => col.Resistence);
            modelVehicle.Property(col => col.MaxKm);

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
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
