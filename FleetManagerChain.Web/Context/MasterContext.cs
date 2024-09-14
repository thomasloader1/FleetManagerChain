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

    public virtual DbSet<User> Users { get; set; }

    
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
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
