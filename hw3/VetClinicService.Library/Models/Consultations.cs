using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicService.Library.Models
{
    [Table("Consultations", Schema = "Job")]
    public class Consultation
	{
        [Required]
        [Column("id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("client_id")]
        [ForeignKey(nameof(Client))]
        public int ClientId { get; set; }

        [Column("pet_id")]
        [ForeignKey(nameof(Pet))]
        public int PetId { get; set; }  //не добавил [Required] потому что мог прийти клиент на консультацию без животного

        [Required]
        [Column("consultation_date")]
        public DateTime ConsultationDate { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Required]
        [Column("client_link")]
        public Client Client { get; set; }

        [Column("pet_link")]
        public Pet Pet { get; set; }
    }
}

