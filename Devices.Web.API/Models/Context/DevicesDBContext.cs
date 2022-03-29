using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Devices.Web.API.Models.Entities;

namespace Devices.Web.API.Models.Context
{
    public partial class DevicesDBContext : DbContext
    {
        public DevicesDBContext()
        {
        }

        public DevicesDBContext(DbContextOptions<DevicesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; } = null!;
        public virtual DbSet<DeviceStatus> DeviceStatuses { get; set; } = null!;
        public virtual DbSet<DeviceType> DeviceTypes { get; set; } = null!;
        public virtual DbSet<DeviceUsage> DeviceUsages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.DeviceStatusId).HasColumnName("DeviceStatusID");

                entity.Property(e => e.DeviceTypeId).HasColumnName("DeviceTypeID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.DeviceStatus)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.DeviceStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_DeviceStatus");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_DeviceType");
            });

            modelBuilder.Entity<DeviceStatus>(entity =>
            {
                entity.ToTable("DeviceStatus");

                entity.Property(e => e.DeviceStatusId).HasColumnName("DeviceStatusID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.ToTable("DeviceType");

                entity.Property(e => e.DeviceTypeId).HasColumnName("DeviceTypeID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<DeviceUsage>(entity =>
            {
                entity.ToTable("DeviceUsage");

                entity.Property(e => e.DeviceUsageId).HasColumnName("DeviceUsageID");

                entity.Property(e => e.DeviceId).HasColumnName("DeviceID");

                entity.Property(e => e.EndUsage).HasColumnType("datetime");

                entity.Property(e => e.StartUsage).HasColumnType("datetime");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.DeviceUsages)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeviceUsage_Device");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
