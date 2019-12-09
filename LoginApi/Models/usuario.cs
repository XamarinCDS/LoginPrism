namespace LoginApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        [Key]
        public int id_usuario { get; set; }

        [StringLength(25)]
        public string usu { get; set; }

        [StringLength(25)]
        public string passw { get; set; }

        [StringLength(25)]
        public string nombre { get; set; }

        [StringLength(12)]
        public string telefono { get; set; }
    }
}
