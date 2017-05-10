namespace WeddingAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("weddingdb.PuntoInteres")]
    public partial class PuntoInteres
    {
        public int PuntoInteresID { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        public float Latitud { get; set; }

        public float Longitud { get; set; }

        [StringLength(45)]
        public string Direccion { get; set; }

        [StringLength(45)]
        public string Url { get; set; }
    }
}
