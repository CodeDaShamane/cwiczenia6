using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cw6.Models
{
    public class Prescription
    {

        [Key]
        public int IdPrescription { get; set; }
        [Required]
        [MaxLength(100)]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(100)]
        public DateTime DueDate { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }

        [ForeignKey("IdPatient")]
        public virtual Patient IdPatientNav { get; set; }
        [ForeignKey("IdDoctor")]
        public virtual Doctor IdDoctorNav { get; set; }

    }
}
