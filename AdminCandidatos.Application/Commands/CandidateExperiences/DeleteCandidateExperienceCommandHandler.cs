using AdminCandidatos.Application.Commands.CandidateExperiences;
using AdminCandidatos.Infrastructure.Persistence;

namespace AdminCandidatos.Application.Handlers.CandidateExperiences
{
    public class DeleteCandidateExperienceCommandHandler
    {
        private readonly AdminCandidatosDBContext _context;

        public DeleteCandidateExperienceCommandHandler(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        public void Handle(DeleteCandidateExperienceCommand command)
        {
            var experience = _context.CandidateExperience
                .FirstOrDefault(e => e.IdCandidateExperience == command.IdCandidateExperience);

            if (experience != null)
            {
                _context.CandidateExperience.Remove(experience);
                _context.SaveChanges();
            }
        }
    }
}
