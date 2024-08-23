using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UniCredit_GroupCo_Loan.BusinessEntities;
 

namespace UniCredit_GroupCo_Loan.DataBaselogic.HotelManagementDBModel;

public partial class HotelManagementContext : DbContext
{
    public HotelManagementContext _hotelManagementContext;
    public HotelManagementContext()
    {
    }

    public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DashBoard> DashBoards { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<NewBooking> NewBookings { get; set; }

    public virtual DbSet<UserRegistration> UserRegistrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-7S1MOM9;Database=HotelManagement;TrustServerCertificate=True;Encrypt=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DashBoard>(entity =>
        {
            entity.HasKey(e => e.Position).HasName("PK__DashBoar__75FE9D9812BA3734");

            entity.ToTable("DashBoard");

            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Location)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Symbol)
                .IsUnicode(false)
                .HasColumnName("symbol");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("weight");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotel__17ADC472A7545844");

            entity.ToTable("Hotel");

            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.HotelDescription)
                .IsUnicode(false)
                .HasColumnName("hotelDescription");
            entity.Property(e => e.HotelImage)
                .IsUnicode(false)
                .HasColumnName("hotelImage");
            entity.Property(e => e.HotelLocation)
                .IsUnicode(false)
                .HasColumnName("hotelLocation");
            entity.Property(e => e.HotelName)
                .IsUnicode(false)
                .HasColumnName("hotelName");
        });

        modelBuilder.Entity<NewBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NewBooki__3213E83FA54FD570");

            entity.ToTable("NewBooking");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.City).IsUnicode(false);
            entity.Property(e => e.Country).IsUnicode(false);
            entity.Property(e => e.CustomerName).IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
        });

        modelBuilder.Entity<UserRegistration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRegi__3213E83F61C6939D");

            entity.ToTable("UserRegistration");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.FirstName).IsUnicode(false);
            entity.Property(e => e.Password)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.UserName).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
