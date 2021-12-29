namespace HCProyecto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Marca")]
    public partial class Marca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marca()
        {
            Categoria = new HashSet<Categoria>();
        }

        [Key]
        public int IDMarca { get; set; }

        [Required]
        [StringLength(250)]
        public string NombreM { get; set; }

        [StringLength(200)]
        public string DescripcionM { get; set; }

        public bool? Activo { get; set; }

        public DateTime? FechaRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Categoria> Categoria { get; set; }
    }
}
