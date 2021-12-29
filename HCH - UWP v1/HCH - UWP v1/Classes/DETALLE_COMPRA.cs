using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCH___UWP_v1.Classes
{
    public partial class DETALLE_COMPRA
    {
        [Key]
        public int IdDetalleCompra { get; set; }

        public int? IdCompra { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Total { get; set; }

        public virtual COMPRA COMPRA { get; set; }

        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
