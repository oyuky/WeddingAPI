namespace WeddingAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("weddingdb.Invitado")]
    public partial class Invitado
    {
        public int InvitadoID { get; set; }

        public int? InvitacionID { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [StringLength(45)]
        public string ApellidoPaterno { get; set; }

        [StringLength(45)]
        public string ApellidoMaterno { get; set; }

        public int? Menor { get; set; }

        public virtual Invitacion Invitacion { get; set; }
    }
}
