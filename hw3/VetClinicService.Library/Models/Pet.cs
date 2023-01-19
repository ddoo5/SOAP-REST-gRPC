using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicService.Library.Models
{
    [Table("Pets", Schema = "Consumer")]
    public class Pet
	{
        [Required]
        [Column("id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("master_id")]
        [ForeignKey(nameof(Master))]
        public int MaseterId { get; set; }

        [Column("moniker")]
        [MaxLength(20)]
        public string Moniker { get; set; }

        [Column("birthday")]
        public DateTime Birthday { get; set; }

        [Column("master_link")]
        public Client Master { get; set; }  //хозяин же у питомца, а не клиент

        [Column("consultations")]
        [InverseProperty(nameof(Consultation.Pet))]
        public ICollection<Consultation> Consultations { get; set; } = new HashSet<Consultation>();
    }
}

