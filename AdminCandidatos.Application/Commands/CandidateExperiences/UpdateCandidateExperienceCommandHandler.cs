using AdminCandidatos.Application.Commands.CandidateExperiences;
using AdminCandidatos.Infrastructure.Persistence;

namespace AdminCandidatos.Application.Handlers.CandidateExperiences
{
    public class UpdateCandidateExperienceCommandHandler
    {
        private readonly AdminCandidatosDBContext _context;

        public UpdateCandidateExperienceCommandHandler(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        public void Handle(UpdateCandidateExperienceCommand command)
        {
            var experience = _context.CandidateExperience
                .FirstOrDefault(e => e.IdCandidateExperience == command.IdCandidateExperience);

            if (experience == null) return;

            experience.Company = command.Company;
            experience.Job = command.Job;
            experience.Description = command.Description;
            experience.Salary = command.Salary;
            experience.BeginDate = command.BeginDate;
            experience.EndDate = command.EndDate;
            experience.ModifyDate = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
