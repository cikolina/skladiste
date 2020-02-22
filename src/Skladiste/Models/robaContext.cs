using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Skladiste.Models
{
    public partial class RobaContext : DbContext
    {
        public RobaContext()
        {
        }

        public RobaContext(DbContextOptions<RobaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Roba20191220> Roba20191220 { get; set; }
        public virtual DbSet<Robanapomene20191220> Robanapomene20191220 { get; set; }

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Roba20191220>(entity =>
            {
                entity.HasKey(e => e.IdRoba);

                entity.ToTable("roba20191220", "roba");

                entity.HasIndex(e => e.SifraProizvoda)
                    .HasName("sifraProizvoda_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdRoba)
                    .HasColumnName("idRoba")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DatumIsporuke)
                    .HasColumnName("datumIsporuke")
                    .HasColumnType("date");

                entity.Property(e => e.SifraProizvoda)
                    .HasColumnName("sifraProizvoda")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("char(1)");

                entity.Property(e => e.Tezina)
                    .HasColumnName("tezina")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Robanapomene20191220>(entity =>
            {
                entity.ToTable("robanapomene20191220", "roba");

                entity.HasIndex(e => e.IdRoba)
                    .HasName("robanapomene20191220_ibfk_1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdRoba)
                    .HasColumnName("idRoba")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Napomena)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRobaNavigation)
                    .WithMany(p => p.Robanapomene20191220)
                    .HasForeignKey(d => d.IdRoba)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("robanapomene20191220_ibfk_1");
            });
        }
    }
}
