﻿using AdminCandidatos.Application.Interfaces.Candidates;
using AdminCandidatos.Infrastructure.Models;
using AdminCandidatos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCandidatos.Application.Queries
{
    public class GetAllCandidatesQueryHandler : IGetAllCandidatesQueryHandler
    {
        private readonly AdminCandidatosDBContext _context;

        public GetAllCandidatesQueryHandler(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        public List<Infrastructure.Models.Candidates> Handle()
        {
            var candidates = _context.Candidates
                .Include(c => c.Experiences)
                .ToList();
            return candidates;
        }

        public List<Infrastructure.Models.Candidates> Handle(GetAllCandidatesQuery query)
        {
            var candidates = _context.Candidates.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Name))
            {
                candidates = candidates.Where(c => c.Name.Contains(query.Name));
            }

            if (!string.IsNullOrWhiteSpace(query.Email))
            {
                candidates = candidates.Where(c => c.Email.Contains(query.Email));
            }

            return candidates.OrderBy(c => c.Name).ToList();
        }

        public IEnumerable<Infrastructure.Models.Candidates> Handle(string name = null, string email = null)
        {
            var query = _context.Candidates
                .Include(c => c.Experiences)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query = query.Where(c => c.Email.Contains(email));
            }

            return query.ToList();
        }

    }
}
