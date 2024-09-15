﻿using System;
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

   public virtual DbSet<User> Users { get; set; }
   public virtual DbSet<Vehicle> Vehicles { get; set; }


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

        modelBuilder.Entity<User>().ToTable("Users");

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

        modelBuilder.Entity<Vehicle>().ToTable("Vehicles");

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
