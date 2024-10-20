using System;
using System.Collections.Generic;
using ElAlAIR.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElAlAIR.DataAccess.DataContext;

public partial class ElalDbContext : DbContext
{
    public ElalDbContext()
    {
    }

    public ElalDbContext(DbContextOptions<ElalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Continent> Continents { get; set; }

    public virtual DbSet<Destination> Destinations { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Rule> Rules { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Continent>(entity =>
        {
            entity.HasKey(e => e.ContinentId).HasName("PK_Table_4");

            entity.ToTable("Continent");

            entity.Property(e => e.ContinentId).ValueGeneratedNever();
            entity.Property(e => e.ContinentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Image).HasColumnName("image");
        });

        modelBuilder.Entity<Destination>(entity =>
        {
            entity.ToTable("Destination");

            entity.Property(e => e.DestinationId).ValueGeneratedNever();
            entity.Property(e => e.CurrencyPayment)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("currency_payment");
            entity.Property(e => e.DepartureAirport)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("departureAirport");
            entity.Property(e => e.Img)
                .IsUnicode(false)
                .HasColumnName("img");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("price");
            entity.Property(e => e.ReturnAirport)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("returnAirport");

            entity.HasOne(d => d.Continent).WithMany(p => p.Destinations)
                .HasForeignKey(d => d.ContinentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Destination_Table_4");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Table_3");
        });

        modelBuilder.Entity<Rule>(entity =>
        {
            entity.Property(e => e.RuleId).ValueGeneratedNever();
            entity.Property(e => e.RuleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.ToTable("Token");

            entity.Property(e => e.TokenId).ValueGeneratedNever();
            entity.Property(e => e.ExpireDate).HasColumnType("datetime");
            entity.Property(e => e.TokenJwt)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Token_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_Table_3");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
