using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LpthLesson10.Models;

public partial class LpthK23cnt1Lesson10DbContext : DbContext
{
    public LpthK23cnt1Lesson10DbContext()
    {
    }

    public LpthK23cnt1Lesson10DbContext(DbContextOptions<LpthK23cnt1Lesson10DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LpthPost> LpthPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-TRL28C8\\SQLEXPRESS;Database=LpthK23CNT1_Lesson10Db;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LpthPost>(entity =>
        {
            entity.HasKey(e => e.LpthId);

            entity.ToTable("LpthPost");

            entity.Property(e => e.LpthId).HasColumnName("lpthId");
            entity.Property(e => e.LpthContent)
                .HasColumnType("ntext")
                .HasColumnName("lpthContent");
            entity.Property(e => e.LpthImage)
                .HasMaxLength(250)
                .HasColumnName("lpthImage");
            entity.Property(e => e.LpthStatus).HasColumnName("lpthStatus");
            entity.Property(e => e.LpthTitle)
                .HasMaxLength(250)
                .HasColumnName("lpthTitle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
