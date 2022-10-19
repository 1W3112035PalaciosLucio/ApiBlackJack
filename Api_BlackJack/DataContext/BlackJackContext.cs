using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api_BlackJack.Models;

namespace Api_BlackJack.DataContext
{
    public partial class BlackJackContext : DbContext
    {
        public BlackJackContext()
        {
        }

        public BlackJackContext(DbContextOptions<BlackJackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carta> Cartas { get; set; } = null!;
        public virtual DbSet<Detallepartidum> Detallepartida { get; set; } = null!;
        public virtual DbSet<Juego> Juegos { get; set; } = null!;
        public virtual DbSet<Partidum> Partida { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=BlackJack;port=3306;user id=root;password=45262", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Carta>(entity =>
            {
                entity.ToTable("cartas");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Disponible)
                    .HasColumnType("bit(1)")
                    .HasColumnName("disponible");

                entity.Property(e => e.Numero).HasColumnName("numero");

                entity.Property(e => e.Palo)
                    .HasMaxLength(2)
                    .HasColumnName("palo");
            });

            modelBuilder.Entity<Detallepartidum>(entity =>
            {
                entity.ToTable("detallepartida");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdPartida, "Usuarios_Cartas_Juegos");

                entity.HasIndex(e => e.IdCarta, "id_carta_idx");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdCarta).HasColumnName("id_carta");

                entity.Property(e => e.IdPartida).HasColumnName("id_partida");

                entity.HasOne(d => d.IdCartaNavigation)
                    .WithMany(p => p.Detallepartida)
                    .HasForeignKey(d => d.IdCarta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UsuariosCartas");

                entity.HasOne(d => d.IdPartidaNavigation)
                    .WithMany(p => p.Detallepartida)
                    .HasForeignKey(d => d.IdPartida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("UsuariosPartidas");
            });

            modelBuilder.Entity<Juego>(entity =>
            {
                entity.ToTable("juegos");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.IdUsuario, "Juegos_Usuarios");

                entity.HasIndex(e => e.Id, "Juegos_Usuarios_idx");

                entity.Property(e => e.Activo)
                    .HasColumnType("bit(1)")
                    .HasColumnName("activo")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Juegos_Usuarios");
            });

            modelBuilder.Entity<Partidum>(entity =>
            {
                entity.ToTable("partida");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Id, "Juegos_Usuarios_idx");

                entity.HasIndex(e => e.IdUsuario, "Partida_Usuarios");

                entity.Property(e => e.Activo)
                    .HasColumnType("bit(1)")
                    .HasColumnName("activo")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Partida)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Partida_Usuarios");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .HasColumnName("apellido");

                entity.Property(e => e.Clave).HasColumnName("clave");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .HasColumnName("nombre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
