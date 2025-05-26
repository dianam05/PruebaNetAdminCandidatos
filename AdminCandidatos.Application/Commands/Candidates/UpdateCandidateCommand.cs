using AdminCandidatos.Infrastructure.Models;

namespace AdminCandidatos.Application.Commands.Candidates
{
    public class UpdateCandidateCommand
    {
        public int IdCandidate { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }

        public List<CandidateExperience> Experiences { get; set; } = new();
    }
}
