namespace WeddingAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("weddingdb.Invitacion")]
    public partial class Invitacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invitacion()
        {
            Invitado = new HashSet<Invitado>();
        }

        public int InvitacionID { get; set; }

        [Required]
        [StringLength(45)]
        public string Familia { get; set; }

        [Required]
        [StringLength(45)]
        public string Email { get; set; }

        [Required]
        [StringLength(45)]
        public string Password { get; set; }

        [Required]
        [StringLength(45)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(45)]
        public string NoPases { get; set; }

        public int? Asisitira { get; set; }

        public int? NoRecordatorio { get; set; }

        public int? Desicion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invitado> Invitado { get; set; }
    }
}
