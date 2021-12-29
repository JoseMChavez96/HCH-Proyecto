namespace dannyprueba.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
