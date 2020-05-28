using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PointsAssetBackend.Api.Models
{
    public partial class AdiraLoyaltyContext : DbContext
    {
        //public AdiraLoyaltyContext()
        //{
        //}

        public AdiraLoyaltyContext(DbContextOptions<AdiraLoyaltyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Issuer> Issuer { get; set; }
        public virtual DbSet<IssuerActive> IssuerActive { get; set; }
        public virtual DbSet<IssuerAttr> IssuerAttr { get; set; }
        public virtual DbSet<PointsAsset> PointsAsset { get; set; }
        public virtual DbSet<PointsLog> PointsLog { get; set; }
        public virtual DbSet<PointsType> PointsType { get; set; }
        public virtual DbSet<PointsTypeActive> PointsTypeActive { get; set; }
        public virtual DbSet<PointsTypeAttr> PointsTypeAttr { get; set; }
        //public virtual DbSet<PointsTypeAll> PointsTypeAll { get; set; }
        //public virtual DbSet<IssuerAll> IssuerAll { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //                optionsBuilder.UseSqlServer("Data Source=DESKTOP-AG0G4RK\\SQLEXPRESS;Initial Catalog=AdiraLoyalty;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Issuer>(entity =>
            {
                entity.HasKey(e => e.IsId);

                entity.Property(e => e.IsId)
                    .HasColumnName("isId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("isActive")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0:inactive, 1:active, 2:suspend, 3:blacklist, 4:deleted");

                entity.Property(e => e.IsClientId).HasColumnName("isClientId");

                entity.Property(e => e.IsName)
                    .HasColumnName("isName")
                    .HasMaxLength(250);

                entity.Property(e => e.IsOrganization).HasColumnName("isOrganization");

                entity.Property(e => e.IsStampToken)
                    .HasColumnName("isStampToken")
                    .HasMaxLength(100);

                entity.Property(e => e.IsUser)
                    .HasColumnName("isUser")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<IssuerActive>(entity =>
            {
                entity.HasKey(e => e.IsaId);

                entity.Property(e => e.IsaId)
                    .HasColumnName("isaId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsId).HasColumnName("isId");

                entity.Property(e => e.IsaActive)
                    .HasColumnName("isaActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsaClient).HasColumnName("isaClient");

                entity.Property(e => e.IsaDate)
                    .HasColumnName("isaDate")
                    .HasColumnType("datetimeoffset(0)");

                entity.Property(e => e.IsaNote).HasColumnName("isaNote");

                entity.Property(e => e.IsaStampToken)
                    .HasColumnName("isaStampToken")
                    .HasMaxLength(50);

                entity.Property(e => e.IsaStatus)
                    .HasColumnName("isaStatus")
                    .HasMaxLength(10)
                    .HasComment("[register, active, inactive, suspend, blacklist, deleted, inworkflow]");

                entity.Property(e => e.IsaUser)
                    .HasColumnName("isaUser")
                    .HasMaxLength(50);

                //entity.HasOne(d => d.Is)
                //    .WithMany(p => p.IssuerActive)
                //    .HasForeignKey(d => d.IsId)
                //    .HasConstraintName("FK_IssuerActive_Issuer");
            });

            modelBuilder.Entity<IssuerAttr>(entity =>
            {
                entity.HasKey(e => e.IstId);

                entity.Property(e => e.IstId)
                    .HasColumnName("istId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IsId).HasColumnName("isId");

                entity.Property(e => e.IstActive)
                    .HasColumnName("istActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IstClient).HasColumnName("istClient");

                entity.Property(e => e.IstCode)
                    .HasColumnName("istCode")
                    .HasMaxLength(10)
                    .HasComment("");

                entity.Property(e => e.IstLock).HasColumnName("istLock");

                entity.Property(e => e.IstName)
                    .HasColumnName("istName")
                    .HasMaxLength(50);

                entity.Property(e => e.IstStampToken)
                    .HasColumnName("istStampToken")
                    .HasMaxLength(50);

                entity.Property(e => e.IstUser)
                    .HasColumnName("istUser")
                    .HasMaxLength(50);

                entity.Property(e => e.IstValueNumeric)
                    .HasColumnName("istValueNumeric")
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IstValueString)
                    .HasColumnName("istValueString")
                    .HasMaxLength(250);

                //entity.HasOne(d => d.Is)
                //    .WithMany(p => p.IssuerAttr)
                //    .HasForeignKey(d => d.IsId)
                //    .HasConstraintName("FK_IssuerAttr_Issuer");
            });

            modelBuilder.Entity<PointsAsset>(entity =>
            {
                entity.HasKey(e => e.PaId);

                entity.Property(e => e.PaId)
                    .HasColumnName("paId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PaClientId).HasColumnName("paClientId");

                entity.Property(e => e.PaCurrency)
                    .HasColumnName("paCurrency")
                    .HasMaxLength(3);

                entity.Property(e => e.PaExpired)
                    .HasColumnName("paExpired")
                    .HasColumnType("datetimeoffset(0)");

                entity.Property(e => e.PaOwner).HasColumnName("paOwner");

                entity.Property(e => e.PaPointsType).HasColumnName("paPointsType");

                entity.Property(e => e.PaPointsValue)
                    .HasColumnName("paPointsValue")
                    .HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PaSerialNo).HasColumnName("paSerialNo");

                entity.Property(e => e.PaStampToken)
                    .HasColumnName("paStampToken")
                    .HasMaxLength(50);

                entity.Property(e => e.PaStatus)
                    .HasColumnName("paStatus")
                    .HasDefaultValueSql("((1))")
                    .HasComment("A: active, U: used, V: void");

                entity.Property(e => e.PaTrx).HasColumnName("paTrx");

                entity.Property(e => e.PaUser)
                    .HasColumnName("paUser")
                    .HasMaxLength(50);

                entity.Property(e => e.PaValue)
                    .HasColumnName("paValue")
                    .HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PaValueFloat)
                    .HasColumnName("paValueFloat")
                    .HasColumnType("decimal(18, 8)");

                entity.Property(e => e.PaValueHold)
                    .HasColumnName("paValueHold")
                    .HasColumnType("decimal(18, 8)");
            });

            modelBuilder.Entity<PointsLog>(entity =>
            {
                entity.HasKey(e => e.PhId);

                entity.Property(e => e.PhId)
                    .HasColumnName("phId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PhClientId).HasColumnName("phClientId");

                entity.Property(e => e.PhRequestData).HasColumnName("phRequestData");

                entity.Property(e => e.PhRequestId)
                    .HasColumnName("phRequestId")
                    .HasMaxLength(50);

                entity.Property(e => e.PhRequestTime)
                    .HasColumnName("phRequestTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhResponseData).HasColumnName("phResponseData");

                entity.Property(e => e.PhResponseId)
                    .HasColumnName("phResponseId")
                    .HasMaxLength(50);

                entity.Property(e => e.PhResponseTime)
                    .HasColumnName("phResponseTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PhUser)
                    .HasColumnName("phUser")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PointsType>(entity =>
            {
                entity.HasKey(e => e.PtId);

                entity.Property(e => e.PtId)
                    .HasColumnName("ptId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PtClient).HasColumnName("ptClient");

                entity.Property(e => e.PtCode)
                    .HasColumnName("ptCode")
                    .HasMaxLength(10);

                entity.Property(e => e.PtDate)
                    .HasColumnName("ptDate")
                    .HasColumnType("datetimeoffset(0)")
                    .HasDefaultValueSql("(sysdatetimeoffset())");

                entity.Property(e => e.PtName)
                    .HasColumnName("ptName")
                    .HasMaxLength(50);

                entity.Property(e => e.PtOrganization).HasColumnName("ptOrganization");

                entity.Property(e => e.PtStampToken)
                    .HasColumnName("ptStampToken")
                    .HasMaxLength(50);

                entity.Property(e => e.PtStatus)
                    .HasColumnName("ptStatus")
                    .HasDefaultValueSql("((0))")
                    .HasComment("0:init, 1:active, 2:suspend, 4:deleted");

                entity.Property(e => e.PtUser)
                    .HasColumnName("ptUser")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PointsTypeActive>(entity =>
            {
                entity.HasKey(e => e.PtaId);

                entity.HasIndex(e => e.PtId)
                    .HasName("IX_PointsTypeActive");

                entity.Property(e => e.PtaId)
                    .HasColumnName("ptaId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PtId).HasColumnName("ptId");

                entity.Property(e => e.PtaActive)
                    .HasColumnName("ptaActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PtaClient).HasColumnName("ptaClient");

                entity.Property(e => e.PtaDate)
                    .HasColumnName("ptaDate")
                    .HasColumnType("datetimeoffset(0)");

                entity.Property(e => e.PtaNote).HasColumnName("ptaNote");

                entity.Property(e => e.PtaStampToken)
                    .HasColumnName("ptaStampToken")
                    .HasMaxLength(50);

                entity.Property(e => e.PtaStatus)
                    .HasColumnName("ptaStatus")
                    .HasMaxLength(10)
                    .HasComment("[register, active, inactive, suspend, blacklist, deleted, inworkflow]");

                entity.Property(e => e.PtaUser)
                    .HasColumnName("ptaUser")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PointsTypeAttr>(entity =>
            {
                entity.HasKey(e => e.PttId);

                entity.HasIndex(e => e.PtId)
                    .HasName("IX_PointsTypeAttr");

                entity.Property(e => e.PttId)
                    .HasColumnName("pttId")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.PtId).HasColumnName("ptId");

                entity.Property(e => e.PttActive)
                    .HasColumnName("pttActive")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PttClient).HasColumnName("pttClient");

                entity.Property(e => e.PttCode)
                    .HasColumnName("pttCode")
                    .HasMaxLength(10)
                    .HasComment("");

                entity.Property(e => e.PttLock).HasColumnName("pttLock");

                entity.Property(e => e.PttName)
                    .HasColumnName("pttName")
                    .HasMaxLength(50);

                entity.Property(e => e.PttStampToken)
                    .HasColumnName("pttStampToken")
                    .HasMaxLength(50);

                entity.Property(e => e.PttUser)
                    .HasColumnName("pttUser")
                    .HasMaxLength(50);

                entity.Property(e => e.PttValueNumeric)
                    .HasColumnName("pttValueNumeric")
                    .HasColumnType("numeric(18, 6)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PttValueString)
                    .HasColumnName("pttValueString")
                    .HasMaxLength(250);
            });

            //modelBuilder.Entity<PointsTypeAll>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.Property(e => e.PtId)
            //         .HasColumnName("ptId")
            //         .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.PtClient).HasColumnName("ptClient");

            //    entity.Property(e => e.PtCode)
            //        .HasColumnName("ptCode")
            //        .HasMaxLength(10);

            //    entity.Property(e => e.PtDate)
            //        .HasColumnName("ptDate")
            //        .HasColumnType("datetimeoffset(0)")
            //        .HasDefaultValueSql("(sysdatetimeoffset())");

            //    entity.Property(e => e.PtName)
            //        .HasColumnName("ptName")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.PtOrganization).HasColumnName("ptOrganization");

            //    entity.Property(e => e.PtStampToken)
            //        .HasColumnName("ptStampToken")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.PtStatus)
            //        .HasColumnName("ptStatus")
            //        .HasDefaultValueSql("((0))")
            //        .HasComment("0:init, 1:active, 2:suspend, 4:deleted");

            //    entity.Property(e => e.PtUser)
            //        .HasColumnName("ptUser")
            //        .HasMaxLength(50);

            //    //entity.HasKey(e => e.PttId);

            //    entity.HasIndex(e => e.PtId)
            //        .HasName("IX_PointsTypeAttr");

            //    entity.Property(e => e.PttId)
            //        .HasColumnName("pttId")
            //        .HasDefaultValueSql("(newid())");

            //    entity.Property(e => e.PtId).HasColumnName("ptId");

            //    entity.Property(e => e.PttActive)
            //        .HasColumnName("pttActive")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.PttClient).HasColumnName("pttClient");

            //    entity.Property(e => e.PttCode)
            //        .HasColumnName("pttCode")
            //        .HasMaxLength(10)
            //        .HasComment("");

            //    entity.Property(e => e.PttLock).HasColumnName("pttLock");

            //    entity.Property(e => e.PttName)
            //        .HasColumnName("pttName")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.PttStampToken)
            //        .HasColumnName("pttStampToken")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.PttUser)
            //        .HasColumnName("pttUser")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.PttValueNumeric)
            //        .HasColumnName("pttValueNumeric")
            //        .HasColumnType("numeric(18, 6)")
            //        .HasDefaultValueSql("((0))");

            //    entity.Property(e => e.PttValueString)
            //        .HasColumnName("pttValueString")
            //        .HasMaxLength(250);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
