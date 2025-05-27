using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCandidatos.Infrastructure.Models
{
    public class Candidates
    {
        [Key]
        public int IdCandidate { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]

        [Required]
        public DateTime Birthdate { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public virtual ICollection<CandidateExperience> Experiences { get; set; } = new List<CandidateExperience>();

    }
}
