using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LePhanTrungHieu_2310900036.Models;

public partial class LePhanTrungHieu2310900036Context : DbContext
{
    public LePhanTrungHieu2310900036Context()
    {
    }

    public LePhanTrungHieu2310900036Context(DbContextOptions<LePhanTrungHieu2310900036Context> options)
        : base(options)
    {
    }

    public virtual DbSet<LpthEmployee> LpthEmployees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-TRL28C8\\SQLEXPRESS;Database=LePhanTrungHieu_2310900036;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LpthEmployee>(entity =>
        {
            entity.HasKey(e => e.LpthEmpId).HasName("PK__LpthEmpl__00001D3866946854");

            entity.ToTable("LpthEmployee");

            entity.Property(e => e.LpthEmpId).ValueGeneratedNever();
            entity.Property(e => e.LpthEmpLevel).HasMaxLength(50);
            entity.Property(e => e.LpthEmpName).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
