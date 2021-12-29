namespace HCProyecto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categoria")]
    public partial class Categoria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categoria()
        {
            Producto = new HashSet<Producto>();
        }

        [Key]
        public int IDCategoria { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreC { get; set; }

        [StringLength(400)]
        public string DescripcionC { get; set; }

        public bool? Activo { get; set; }

        public int IDMarca { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public virtual Marca Marca { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
