using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCH___UWP_v1.Classes
{
    [Table("PRODUCTO")]
    public partial class PRODUCTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCTO()
        {
            CARRITO = new HashSet<CARRITO>();
            DETALLE_COMPRA = new HashSet<DETALLE_COMPRA>();
        }

        [Key]
        public int IdProducto { get; set; }

        [StringLength(500)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        public int? IdMarca { get; set; }

        public int? IdCategoria { get; set; }

        public decimal? Precio { get; set; }

        public int? Stock { get; set; }

        [StringLength(100)]
        public string RutaImagen { get; set; }

        public bool? Activo { get; set; }

        public DateTime? FechaRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITO> CARRITO { get; set; }

        public virtual CATEGORIA CATEGORIA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLE_COMPRA> DETALLE_COMPRA { get; set; }

        public virtual MARCA MARCA { get; set; }
    }
}
