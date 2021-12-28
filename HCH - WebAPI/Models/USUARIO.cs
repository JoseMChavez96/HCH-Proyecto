namespace HCH___WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USUARIO")]
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            CARRITOes = new HashSet<CARRITO>();
            COMPRAs = new HashSet<COMPRA>();
        }

        [Key]
        public int IdUsuario { get; set; }

        [StringLength(100)]
        public string Nombres { get; set; }

        [StringLength(100)]
        public string Apellidos { get; set; }

        [StringLength(100)]
        public string Correo { get; set; }

        [StringLength(100)]
        public string Contrasena { get; set; }

        public bool? EsAdministrador { get; set; }

        public bool? Activo { get; set; }

        public DateTime? FechaRegistro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CARRITO> CARRITOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMPRA> COMPRAs { get; set; }
    }
}
