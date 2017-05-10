namespace WeddingAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("weddingdb.MesaRegalo")]
    public partial class MesaRegalo
    {
        public int MesaRegaloID { get; set; }

        [Required]
        [StringLength(45)]
        public string Tienda { get; set; }

        [Required]
        [StringLength(45)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(45)]
        public string ImagenID { get; set; }
    }
}
