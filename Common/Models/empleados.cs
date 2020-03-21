namespace Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("developer.empleados")]
    public partial class empleados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public empleados()
        {
            empleados1 = new HashSet<empleados>();
            telefonos = new HashSet<telefonos>();
        }

        [Key]
        public int Empleado_Id { get; set; }

        public int Cargo_Id { get; set; }

        public int Tipo_Documento_Id { get; set; }

        [Required]
        [StringLength(15)]
        public string NumeroDocumento { get; set; }

        [Required]
        [StringLength(20)]
        public string Primer_Nombre { get; set; }

        [StringLength(20)]
        public string Segundo_Nombre { get; set; }

        [Required]
        [StringLength(20)]
        public string Primer_Apellido { get; set; }

        [StringLength(20)]
        public string Segundo_Apellido { get; set; }

        public DateTime Fecha_Nacimiento { get; set; }

        public int? Salario { get; set; }

        public int? Jefe { get; set; }

        public DateTime? Fecha_Registro { get; set; }

        public virtual cargos cargos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empleados> empleados1 { get; set; }

        public virtual empleados empleados2 { get; set; }

        public virtual tiposdocumentos tiposdocumentos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<telefonos> telefonos { get; set; }
    }
}
