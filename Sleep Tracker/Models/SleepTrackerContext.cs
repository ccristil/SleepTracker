using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sleep_Tracker.Models;

public partial class SleepTrackerContext : DbContext
{
    public SleepTrackerContext()
    {
    }

    public SleepTrackerContext(DbContextOptions<SleepTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiaperChange> DiaperChanges { get; set; }

    public virtual DbSet<Night> Nights { get; set; }

    public virtual DbSet<Parent> Parents { get; set; }

    public virtual DbSet<Pump> Pumps { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=SleepTracker.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiaperChange>(entity =>
        {
            entity.ToTable("DiaperChange");

            entity.Property(e => e.DiaperChangeId).HasColumnName("DiaperChangeID");
        });

        modelBuilder.Entity<Night>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Night");
        });

        modelBuilder.Entity<Parent>(entity =>
        {
            entity.ToTable("Parent");

            entity.Property(e => e.ParentId).HasColumnName("ParentID");
        });

        modelBuilder.Entity<Pump>(entity =>
        {
            entity.ToTable("Pump");

            entity.Property(e => e.PumpId).HasColumnName("PumpID");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.ToTable("Shift");

            entity.Property(e => e.ShiftId).HasColumnName("ShiftID");
            entity.Property(e => e.TimeWindow).HasColumnName("Time Window");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
