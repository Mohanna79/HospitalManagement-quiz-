using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HospitalManagement.Models
{
    public partial class MedicalManagementContext : DbContext
    {
        public MedicalManagementContext()
        {
        }

        public MedicalManagementContext(DbContextOptions<MedicalManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Examination> Examinations { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Reception> Receptions { get; set; }
        public virtual DbSet<ReceptionExamination> ReceptionExaminations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=EBRAHIMI; Initial Catalog=MedicalManagement; User ID=sa; Password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Examination>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NationalCode)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Reception>(entity =>
            {
                entity.HasIndex(e => e.PatientId, "IX_ExaminationGroupReceptions_PatientId");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Receptions)
                    .HasForeignKey(d => d.DoctorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receptions_Doctors");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Receptions)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receptions_Patients");
            });

            modelBuilder.Entity<ReceptionExamination>(entity =>
            {
                entity.HasOne(d => d.Examination)
                    .WithMany(p => p.ReceptionExaminations)
                    .HasForeignKey(d => d.ExaminationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceptionExaminations_Examinatios");

                entity.HasOne(d => d.Reception)
                    .WithMany(p => p.ReceptionExaminations)
                    .HasForeignKey(d => d.ReceptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceptionExaminations_Receptions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
