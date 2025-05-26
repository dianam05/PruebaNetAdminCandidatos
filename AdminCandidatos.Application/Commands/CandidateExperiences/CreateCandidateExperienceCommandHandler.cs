using AdminCandidatos.Application.Commands.CandidateExperiences;
using AdminCandidatos.Infrastructure.Models;
using AdminCandidatos.Infrastructure.Persistence;

namespace AdminCandidatos.Application.Handlers.CandidateExperiences
{
    public class CreateCandidateExperienceCommandHandler
    {
        private readonly AdminCandidatosDBContext _context;

        public CreateCandidateExperienceCommandHandler(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        public void Handle(CreateCandidateExperienceCommand command)
        {
            var experience = new CandidateExperience
            {
                IdCandidate = command.IdCandidate,
                Company = command.Company,
                Job = command.Job,
                Description = command.Description,
                Salary = command.Salary,
                BeginDate = command.BeginDate,
                EndDate = command.EndDate,
                InsertDate = DateTime.Now,
                ModifyDate = DateTime.Now
            };

            _context.CandidateExperience.Add(experience);
            _context.SaveChanges();
        }
    }
}
