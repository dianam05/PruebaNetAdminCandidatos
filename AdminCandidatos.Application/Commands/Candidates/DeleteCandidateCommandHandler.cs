using AdminCandidatos.Application.Commands.Candidates;
using AdminCandidatos.Application.Interfaces.Candidates;
using AdminCandidatos.Infrastructure;
using AdminCandidatos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdminCandidatos.Application.Commands.Candidates
{
    public class DeleteCandidateCommandHandler : IDeleteCandidateCommandHandler
    {
        private readonly AdminCandidatosDBContext _context;

        public DeleteCandidateCommandHandler(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        public void Handle(DeleteCandidateCommand command)
        {
            var candidate = _context.Candidates
                .Include(c => c.Experiences)
                .FirstOrDefault(c => c.IdCandidate == command.IdCandidate);

            if (candidate == null)
                return;

            // Eliminar experiencias primero
            _context.CandidateExperience.RemoveRange(candidate.Experiences);

            // Eliminar candidato
            _context.Candidates.Remove(candidate);

            _context.SaveChanges();
        }
    }
}

