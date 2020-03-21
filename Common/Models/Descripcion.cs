namespace Common.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("developer.Descripcion")]
    public partial class Descripcion
    {
        [Key]
        public int Tipo_Documento_Id { get; set; }

        [Required]
        [StringLength(5)]
        public string Tipo_Documento { get; set; }

        [Column("Descripcion")]
        [Required]
        [StringLength(50)]
        public string Descripcion1 { get; set; }

        public DateTime? Fecha_Registro { get; set; }
    }
}
