namespace WeddingAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WeddingModel : DbContext
    {
        public WeddingModel()
            : base("name=WeddingModel")
        {
        }

        public virtual DbSet<Invitacion> Invitacion { get; set; }
        public virtual DbSet<Invitado> Invitado { get; set; }
        public virtual DbSet<MesaRegalo> MesaRegalo { get; set; }
        public virtual DbSet<PuntoInteres> PuntoInteres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invitacion>()
                .Property(e => e.Familia)
                .IsUnicode(false);

            modelBuilder.Entity<Invitacion>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Invitacion>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Invitacion>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Invitacion>()
                .Property(e => e.NoPases)
                .IsUnicode(false);

            modelBuilder.Entity<Invitado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Invitado>()
                .Property(e => e.ApellidoPaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Invitado>()
                .Property(e => e.ApellidoMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<MesaRegalo>()
                .Property(e => e.Tienda)
                .IsUnicode(false);

            modelBuilder.Entity<MesaRegalo>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<MesaRegalo>()
                .Property(e => e.ImagenID)
                .IsUnicode(false);

            modelBuilder.Entity<PuntoInteres>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PuntoInteres>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<PuntoInteres>()
                .Property(e => e.Url)
                .IsUnicode(false);
        }
    }
}
