using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RPayGateway.Models
{
    public partial class RadixPayContext : DbContext
    {
        public RadixPayContext()
        {
        }

        public RadixPayContext(DbContextOptions<RadixPayContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adquirente> Adquirente { get; set; }
        public virtual DbSet<AdquirenteEndpoint> AdquirenteEndpoint { get; set; }
        public virtual DbSet<Antifraude> Antifraude { get; set; }
        public virtual DbSet<AntifraudeEndpoint> AntifraudeEndpoint { get; set; }
        public virtual DbSet<Bandeira> Bandeira { get; set; }
        public virtual DbSet<LogTrans> LogTrans { get; set; }
        public virtual DbSet<Lojista> Lojista { get; set; }
        public virtual DbSet<LojistaCfg> LojistaCfg { get; set; }
        public virtual DbSet<LojistaCfgBandeira> LojistaCfgBandeira { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adquirente>(entity =>
            {
                entity.HasKey(e => e.IdAdquirente)
                    .HasName("PK__Adquiren__B2E07CB491BFC9CE");

                entity.Property(e => e.DscAdquirente)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<AdquirenteEndpoint>(entity =>
            {
                entity.HasKey(e => e.IdAdquirenteEndpoint)
                    .HasName("PK__Adquiren__16B10338F707FCB9");

                entity.Property(e => e.DscUrl)
                    .IsRequired()
                    .HasColumnName("DscURL")
                    .HasMaxLength(128);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdAdquirenteNavigation)
                    .WithMany(p => p.AdquirenteEndpoint)
                    .HasForeignKey(d => d.IdAdquirente)
                    .HasConstraintName("FK__Adquirent__Id_Ad__5070F446");
            });

            modelBuilder.Entity<Antifraude>(entity =>
            {
                entity.HasKey(e => e.IdAntifraude)
                    .HasName("PK__Antifrau__82771482EBE3E2C5");

                entity.Property(e => e.DscAntifraude)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<AntifraudeEndpoint>(entity =>
            {
                entity.HasKey(e => e.IdAntifraudeEndpoint)
                    .HasName("PK__Antifrau__C0057B3908433CA0");

                entity.Property(e => e.DscEndpoint)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdAntifraudeNavigation)
                    .WithMany(p => p.AntifraudeEndpoint)
                    .HasForeignKey(d => d.IdAntifraude)
                    .HasConstraintName("FK__Antifraud__Id_An__6383C8BA");
            });

            modelBuilder.Entity<Bandeira>(entity =>
            {
                entity.HasKey(e => e.IdBandeira)
                    .HasName("PK__Bandeira__AC7BBAB0015C95E9");

                entity.Property(e => e.DscBandeira)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<LogTrans>(entity =>
            {
                entity.HasKey(e => e.IdLogTrans)
                    .HasName("PK__Log_Tran__8BFE815CC8C94A3C");

                entity.Property(e => e.DtTrans)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StrReqJson).IsRequired();

                entity.HasOne(d => d.IdLojistaNavigation)
                    .WithMany(p => p.LogTrans)
                    .HasForeignKey(d => d.IdLojista)
                    .HasConstraintName("FK__Log_Trans__Id_Lo__75A278F5");

                entity.HasOne(d => d.IdLojistaCfgNavigation)
                    .WithMany(p => p.LogTrans)
                    .HasForeignKey(d => d.IdLojistaCfg)
                    .HasConstraintName("FK__Log_Trans__Id_Lo__76969D2E");

                entity.HasOne(d => d.IdLojistaCfgBandeiraNavigation)
                    .WithMany(p => p.LogTrans)
                    .HasForeignKey(d => d.IdLojistaCfgBandeira)
                    .HasConstraintName("FK__Log_Trans__Id_Lo__778AC167");
            });

            modelBuilder.Entity<Lojista>(entity =>
            {
                entity.HasKey(e => e.IdLojista)
                    .HasName("PK__Lojista__BC7DA3129AAAE493");

                entity.Property(e => e.BlAtivo)
                    .HasColumnName("blAtivo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(128);

                entity.Property(e => e.DscLojista)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<LojistaCfg>(entity =>
            {
                entity.HasKey(e => e.IdLojistaCfg)
                    .HasName("PK__Lojista___D718AB5148EF1711");

                entity.Property(e => e.DscCfg).HasMaxLength(50);

                entity.HasOne(d => d.IdLojistaNavigation)
                    .WithMany(p => p.LojistaCfg)
                    .HasForeignKey(d => d.IdLojista)
                    .HasConstraintName("FK__Lojista_C__Id_Lo__5629CD9C");
            });

            modelBuilder.Entity<LojistaCfgBandeira>(entity =>
            {
                entity.HasKey(e => e.IdLojistaCfgBandeira)
                    .HasName("PK__Lojista___A433ADBE492801A8");

                entity.HasOne(d => d.IdAdquirenteNavigation)
                    .WithMany(p => p.LojistaCfgBandeira)
                    .HasForeignKey(d => d.IdAdquirente)
                    .HasConstraintName("FK__Lojista_C__Id_Ad__5AEE82B9");

                entity.HasOne(d => d.IdBandeiraNavigation)
                    .WithMany(p => p.LojistaCfgBandeira)
                    .HasForeignKey(d => d.IdBandeira)
                    .HasConstraintName("FK__Lojista_C__Id_Ba__59FA5E80");

                entity.HasOne(d => d.IdLojistaCfgNavigation)
                    .WithMany(p => p.LojistaCfgBandeira)
                    .HasForeignKey(d => d.IdLojistaCfg)
                    .HasConstraintName("FK__Lojista_C__Id_Lo__59063A47");
            });
        }
    }
}
