using AdminCandidatos.Application.Commands.Candidates;
using AdminCandidatos.Infrastructure;
using AdminCandidatos.Infrastructure.Models;
using AdminCandidatos.Infrastructure.Persistence;
using System;

namespace AdminCandidatos.Application.Commands.Candidates
{
    public class CreateCandidateCommandHandler
    {
        private readonly AdminCandidatosDBContext _context;

        public CreateCandidateCommandHandler(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        public void Handle(CreateCandidateCommand command)
        {
            var now = DateTime.Now;

            var candidate = new AdminCandidatos.Infrastructure.Models.Candidates
            {
                Name = command.Name,
                Surname = command.Surname,
                Birthdate = command.Birthdate,
                Email = command.Email,
                InsertDate = now,
                ModifyDate = now,
                Experiences = command.Experiences.Select(e => new CandidateExperience
                {
                    Company = e.Company,
                    Job = e.Job,
                    Description = e.Description,
                    Salary = e.Salary,
                    BeginDate = e.BeginDate,
                    EndDate = e.EndDate,
                    InsertDate = now,
                    ModifyDate = now
                }).ToList()
            };

            _context.Candidates.Add(candidate);
            _context.SaveChanges();
        }
    }
}
