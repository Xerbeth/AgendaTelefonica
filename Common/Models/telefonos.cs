namespace Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("developer.telefonos")]
    public partial class telefonos
    {
        [Key]
        public int Telefono_Id { get; set; }

        public int Tipo_Telefono_Id { get; set; }

        [StringLength(15)]
        public string NumeroTelefonico { get; set; }

        public int Empleado_Id { get; set; }

        public DateTime? Fecha_Registro { get; set; }

        public virtual empleados empleados { get; set; }

        public virtual tipostelefonos tipostelefonos { get; set; }
    }
}
