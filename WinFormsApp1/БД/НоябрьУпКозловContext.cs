using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp1;

public partial class НоябрьУпКозловContext : DbContext
{
    public НоябрьУпКозловContext()
    {
    }

    public НоябрьУпКозловContext(DbContextOptions<НоябрьУпКозловContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Autorisation> Autorisations { get; set; }

    public virtual DbSet<ВыбранныеТемы> ВыбранныеТемыs { get; set; }

    public virtual DbSet<Отметки> Отметкиs { get; set; }

    public virtual DbSet<Преподаватели> Преподавателиs { get; set; }

    public virtual DbSet<Студенты> Студентыs { get; set; }

    public virtual DbSet<Темы> Темыs { get; set; }

    public virtual DbSet<History> Histories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog = НоябрьУпКозлов ;Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<History>(entity =>
        {
            entity
                .HasKey(e => e.Date);
            entity
                .ToTable("History");

            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");

            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");

            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");

            entity.Property(e => e.Date)
                .HasColumnName("date");
        });


        modelBuilder.Entity<Autorisation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Autorisation");

            entity.Property(e => e.Login)
                .HasMaxLength(20)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasColumnName("role");
        });

        modelBuilder.Entity<ВыбранныеТемы>(entity =>
        {
            entity.HasKey(e => e.Тема);

            entity.ToTable("Выбранные темы");

            entity.Property(e => e.Тема).HasMaxLength(80);
            entity.Property(e => e.НомерЗачетнойКнижки).HasColumnName("Номер Зачетной книжки");

            entity.HasOne(d => d.НомерЗачетнойКнижкиNavigation).WithMany(p => p.ВыбранныеТемыs)
                .HasForeignKey(d => d.НомерЗачетнойКнижки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Выбранные темы_Студенты");
        });

        modelBuilder.Entity<Отметки>(entity =>
        {
            entity.HasKey(e => e.НомерЗачетнойКнижки);

            entity.ToTable("Отметки");

            entity.Property(e => e.НомерЗачетнойКнижки)
                .ValueGeneratedNever()
                .HasColumnName("Номер Зачетной книжки");
            entity.Property(e => e.ОценкаГосэкзамен).HasColumnName("Оценка госэкзамен");
            entity.Property(e => e.ОценкаДиплом).HasColumnName("Оценка диплом");

            entity.HasOne(d => d.НомерЗачетнойКнижкиNavigation).WithOne(p => p.Отметки)
                .HasForeignKey<Отметки>(d => d.НомерЗачетнойКнижки)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Отметки_Студенты");
        });

        modelBuilder.Entity<Преподаватели>(entity =>
        {
            entity.HasKey(e => e.КодПреподавателя);

            entity.ToTable("Преподаватели");

            entity.Property(e => e.КодПреподавателя)
                .ValueGeneratedNever()
                .HasColumnName("Код преподавателя");
            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.Звание).HasMaxLength(80);
            entity.Property(e => e.Кафедра).HasMaxLength(80);
            entity.Property(e => e.Степень).HasMaxLength(80);
            entity.Property(e => e.Телефон).HasMaxLength(11);
            entity.Property(e => e.Фио)
                .HasMaxLength(80)
                .HasColumnName("ФИО");

            entity.HasOne(d => d.КодПреподавателяNavigation).WithOne(p => p.Преподаватели)
                .HasForeignKey<Преподаватели>(d => d.КодПреподавателя)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Преподаватели_Темы");
        });

        modelBuilder.Entity<Студенты>(entity =>
        {
            entity.HasKey(e => e.НомерЗачетнойКнижки);

            entity.ToTable("Студенты");

            entity.Property(e => e.НомерЗачетнойКнижки)
                .ValueGeneratedNever()
                .HasColumnName("Номер Зачетной книжки");
            entity.Property(e => e.Группа).HasMaxLength(80);
            entity.Property(e => e.Факультет).HasMaxLength(80);
            entity.Property(e => e.Фио)
                .HasMaxLength(80)
                .HasColumnName("ФИО");
        });

        modelBuilder.Entity<Темы>(entity =>
        {
            entity.HasKey(e => e.КодПреподавателя);

            entity.ToTable("Темы");

            entity.Property(e => e.КодПреподавателя)
                .ValueGeneratedNever()
                .HasColumnName("Код преподавателя");
            entity.Property(e => e.ТемаДипломнойРаботы)
                .HasMaxLength(80)
                .HasColumnName("Тема дипломной работы");

            entity.HasOne(d => d.ТемаДипломнойРаботыNavigation).WithMany(p => p.Темыs)
                .HasForeignKey(d => d.ТемаДипломнойРаботы)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Темы_Выбранные темы");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
