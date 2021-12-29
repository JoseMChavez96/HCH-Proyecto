using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace dannyprueba.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CARRITO> CARRITO { get; set; }
        public virtual DbSet<CATEGORIA> CATEGORIA { get; set; }
        public virtual DbSet<COMPRA> COMPRA { get; set; }
        public virtual DbSet<DETALLE_COMPRA> DETALLE_COMPRA { get; set; }
        public virtual DbSet<MARCA> MARCA { get; set; }
        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<USUARIO> USUARIO { get; set; }

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
