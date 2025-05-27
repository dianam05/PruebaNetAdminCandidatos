using AdminCandidatos.Application.Commands.Candidates;
using AdminCandidatos.Application.Interfaces;
using AdminCandidatos.Application.Interfaces.Candidates;
using AdminCandidatos.Infrastructure;
using AdminCandidatos.Infrastructure.Models;
using AdminCandidatos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;

namespace AdminCandidatos.Application.Commands.Candidates
{
    public class CreateCandidateCommandHandler : ICreateCandidateCommandHandler
    {
        private readonly AdminCandidatosDBContext _context;

        public CreateCandidateCommandHandler(AdminCandidatosDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Handle(CreateCandidateCommand command)
        {
            try
            {
                var entity = new Infrastructure.Models.Candidates
            {
                Name = command.Name,
                Surname = command.Surname,
                Birthdate = command.Birthdate,
                Email = command.Email,
                InsertDate = DateTime.Now,
                ModifyDate = DateTime.Now
            };

            _context.Candidates.Add(entity);
            _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error al guardar el candidato: " + ex.InnerException?.Message, ex);
            }
        }


    }
}
