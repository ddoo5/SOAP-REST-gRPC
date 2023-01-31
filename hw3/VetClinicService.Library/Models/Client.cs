using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicService.Library.Models
{
	[Table("Clients", Schema = "Consumer")]
    public class Client
	{
        [Required]
        [Column("id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

        [Required]
        [Column("docs")]
		[MaxLength(50)]
		public string Document { get; set; }

        [Required]
        [Column("last_name")]
        [MaxLength(255)]
        public string Lastname { get; set; }

        [Required]
        [Column("first_name")]
        [MaxLength(255)]
        public string Firstname { get; set; }

        [Column("patronymic")]
        [MaxLength(255)]
        public string Patronymic { get; set; }

        [Column("pets")]
        [InverseProperty(nameof(Pet.Master))]
        public ICollection<Pet> Pets { get; set; } = new HashSet<Pet>();

        [Column("consultations")]
        [InverseProperty(nameof(Consultation.Client))]
        public ICollection<Consultation> Consultations { get; set; } = new HashSet<Consultation>();
    }
}

