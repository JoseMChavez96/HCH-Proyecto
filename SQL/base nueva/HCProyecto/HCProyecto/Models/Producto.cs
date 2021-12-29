namespace HCProyecto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [Key]
        public int IDProducto { get; set; }

        [Required]
        [StringLength(250)]
        public string NombreP { get; set; }

        [StringLength(250)]
        public string DescripcionP { get; set; }

        public short? Precio { get; set; }

        public short? stock { get; set; }

        public int IDCategoria { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
