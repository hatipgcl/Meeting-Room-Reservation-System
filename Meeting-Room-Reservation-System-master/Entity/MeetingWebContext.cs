using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Entity;

public partial class MeetingWebContext : DbContext
{
    public MeetingWebContext()
    {
    }

    public MeetingWebContext(DbContextOptions<MeetingWebContext> options)
        : base(options)
    {
    }
    public  DbSet<OperationClaim> OperationClaims { get; set; }
    public  DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<LocationToRoom> LocationToRooms { get; set; }

    public virtual DbSet<MeetingEquipment> MeetingEquipments { get; set; }

    public virtual DbSet<MeetingRequest> MeetingRequests { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomToEquipment> RoomToEquipments { get; set; }

    public virtual DbSet<Stafftitle> Stafftitles { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=>optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=MeetingWeb;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.Property(e => e.EquipmentName).HasMaxLength(30);
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUserId).HasColumnName("InsertUserID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.Property(e => e.GenderName).HasMaxLength(10);
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUserId).HasColumnName("InsertUserID");
            entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.Adress).HasMaxLength(300);
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUserId).HasColumnName("InsertUserID");
            entity.Property(e => e.LocationName).HasMaxLength(100);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
        });

        modelBuilder.Entity<LocationToRoom>(entity =>
        {
            entity.HasKey(e => e.LocationToRoomsId);

            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUserId).HasColumnName("InsertUserID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

            entity.HasOne(d => d.Location).WithMany(p => p.LocationToRooms)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocationToRooms_Locations");
        });

        modelBuilder.Entity<MeetingEquipment>(entity =>
        {
            entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUserId).HasColumnName("InsertUserID");
            entity.Property(e => e.MeetingRequestId).HasColumnName("MeetingRequestID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

            entity.HasOne(d => d.Equipment).WithMany(p => p.MeetingEquipments)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MeetingEquipments_Equipments");

            entity.HasOne(d => d.MeetingRequest).WithMany(p => p.MeetingEquipments)
                .HasForeignKey(d => d.MeetingRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MeetingEquipments_MeetingRequest");
        });

        modelBuilder.Entity<MeetingRequest>(entity =>
        {
            entity.ToTable("MeetingRequest");

            entity.Property(e => e.EndTime).HasMaxLength(30);
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUserId).HasColumnName("InsertUserID");
            entity.Property(e => e.MeetingDate).HasColumnType("datetime");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.StartTime).HasMaxLength(30);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
        });


        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUserId).HasColumnName("InsertUserID");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.RoomName).HasMaxLength(100);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
        });

        modelBuilder.Entity<RoomToEquipment>(entity =>
        {
            entity.Property(e => e.EquipmentId).HasColumnName("EquipmentID");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUserId).HasColumnName("InsertUserID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");

            entity.HasOne(d => d.Equipment).WithMany(p => p.RoomToEquipments)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomToEquipments_Equipments");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomToEquipments)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RoomToEquipments_Rooms");
        });

        modelBuilder.Entity<Stafftitle>(entity =>
        {
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUserId).HasColumnName("InsertUserID");
            entity.Property(e => e.StafftitleName).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.GenderId).HasColumnName("GenderID");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.InsertUserId).HasColumnName("InsertUserID");
            entity.Property(e => e.StafftitleId).HasColumnName("StafftitleID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            entity.Property(e => e.UserName).HasMaxLength(100);
            entity.Property(e => e.UserSurname).HasMaxLength(100);

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("FK_Users_Genders");

            entity.HasOne(d => d.Stafftitle).WithMany(p => p.Users)
                .HasForeignKey(d => d.StafftitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Stafftitles");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
