using AdminCandidatos.Application.Interfaces.Candidates;
using AdminCandidatos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCandidatos.Application.Commands.Candidates
{
    public class UpdateCandidateCommandHandler : IUpdateCandidateCommandHandler
    {
        private readonly AdminCandidatosDBContext _context;

        public UpdateCandidateCommandHandler(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        public void Handle(UpdateCandidateCommand command)
        {
            var candidate = _context.Candidates
                .Include(c => c.Experiences)
                .FirstOrDefault(c => c.IdCandidate == command.IdCandidate);

            if (candidate == null)
                return;

            // Actualizar propiedades básicas
            candidate.Name = command.Name;
            candidate.Surname = command.Surname;
            candidate.Birthdate = command.Birthdate;
            candidate.Email = command.Email;
            candidate.ModifyDate = DateTime.Now;

            // Eliminar experiencias que ya no están
            var existingIds = command.Experiences.Select(e => e.IdCandidateExperience).ToList();
            var experiencesToRemove = candidate.Experiences
                .Where(e => !existingIds.Contains(e.IdCandidateExperience))
                .ToList();

            _context.CandidateExperience.RemoveRange(experiencesToRemove);

            // Actualizar o agregar experiencias
            foreach (var exp in command.Experiences)
            {
                var existing = candidate.Experiences
                    .FirstOrDefault(e => e.IdCandidateExperience == exp.IdCandidateExperience);

                if (existing != null)
                {
                    // Actualizar experiencia existente
                    existing.Company = exp.Company;
                    existing.Job = exp.Job;
                    existing.Description = exp.Description;
                    existing.Salary = exp.Salary;
                    existing.BeginDate = exp.BeginDate;
                    existing.EndDate = exp.EndDate;
                    existing.ModifyDate = DateTime.Now;
                }
                else
                {
                    // Agregar nueva experiencia
                    exp.InsertDate = DateTime.Now;
                    exp.ModifyDate = DateTime.Now;
                    exp.IdCandidate = candidate.IdCandidate;
                    candidate.Experiences.Add(exp);
                }
            }

            _context.SaveChanges();
        }
    }
}
