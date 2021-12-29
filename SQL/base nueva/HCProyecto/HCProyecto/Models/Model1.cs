using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HCProyecto.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.NombreC)
                .IsFixedLength();

            modelBuilder.Entity<Categoria>()
                .Property(e => e.DescripcionC)
                .IsFixedLength();

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Producto)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marca>()
                .Property(e => e.NombreM)
                .IsFixedLength();

            modelBuilder.Entity<Marca>()
                .Property(e => e.DescripcionM)
                .IsFixedLength();

            modelBuilder.Entity<Marca>()
                .HasMany(e => e.Categoria)
                .WithRequired(e => e.Marca)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.NombreP)
                .IsFixedLength();

            modelBuilder.Entity<Producto>()
                .Property(e => e.DescripcionP)
                .IsFixedLength();
        }
    }
}
