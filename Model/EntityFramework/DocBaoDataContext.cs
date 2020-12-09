namespace Model.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DocBaoDataContext : DbContext
    {
        public DocBaoDataContext()
            : base("name=DocBaoDataContext")
        {
        }

        public virtual DbSet<BAIDANG> BAIDANGs { get; set; }
        public virtual DbSet<CHUYENMUC> CHUYENMUCs { get; set; }
        public virtual DbSet<LUOTXEM> LUOTXEMs { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THELOAI> THELOAIs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BAIDANG>()
                .HasMany(e => e.LUOTXEMs)
                .WithRequired(e => e.BAIDANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.QuyenHan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TAIKHOAN>()
                .HasMany(e => e.BAIDANGs)
                .WithRequired(e => e.TAIKHOAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THELOAI>()
                .HasMany(e => e.BAIDANGs)
                .WithRequired(e => e.THELOAI)
                .WillCascadeOnDelete(false);
        }
    }
}
