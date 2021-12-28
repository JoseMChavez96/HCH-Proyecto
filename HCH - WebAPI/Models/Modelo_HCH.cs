using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HCH___WebAPI.Models
{
    public partial class Modelo_HCH : DbContext
    {
        public Modelo_HCH()
            : base("name=HCHModelo")
        {
        }

        public virtual DbSet<CARRITO> CARRITOes { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIAs { get; set; }
        public virtual DbSet<COMPRA> COMPRAs { get; set; }
        public virtual DbSet<DETALLE_COMPRA> DETALLE_COMPRA { get; set; }
        public virtual DbSet<MARCA> MARCAs { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTOes { get; set; }
        public virtual DbSet<USUARIO> USUARIOs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORIA>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.Contacto)
                .IsUnicode(false);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<COMPRA>()
                .Property(e => e.IdDistrito)
                .IsUnicode(false);

            modelBuilder.Entity<DETALLE_COMPRA>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MARCA>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.Precio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.RutaImagen)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<USUARIO>()
                .Property(e => e.Contrasena)
                .IsUnicode(false);
        }
    }
}
