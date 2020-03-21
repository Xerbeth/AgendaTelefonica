namespace ClassLibrary3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("developer.tipostelefonos")]
    public partial class tipostelefonos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipostelefonos()
        {
            telefonos = new HashSet<telefonos>();
        }

        [Key]
        public int Tipo_Telefono_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo_Telefono { get; set; }

        public DateTime? Fecha_Registro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<telefonos> telefonos { get; set; }
    }
}
