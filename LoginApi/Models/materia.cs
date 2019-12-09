namespace LoginApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("materia")]
    public partial class materia
    {
        [Key]
        public int id_materia { get; set; }

        [StringLength(25)]
        public string nombre { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }
    }
}
