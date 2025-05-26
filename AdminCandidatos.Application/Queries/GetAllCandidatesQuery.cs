using AdminCandidatos.Infrastructure.Models;
using AdminCandidatos.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCandidatos.Application.Queries
{
    public class GetAllCandidatesQuery
    {
        private readonly AdminCandidatosDBContext _context;

        public string? Name { get; set; }
        public string? Email { get; set; }

        public GetAllCandidatesQuery() { }

        public GetAllCandidatesQuery(string? name, string? email)
        {
            Name = name;
            Email = email;
        }

        public GetAllCandidatesQuery(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        public async Task<List<Infrastructure.Models.Candidates>> ExecuteAsync()
        {
            return await _context.Candidates
                .Include(c => c.Experiences)
                .ToListAsync();
        }



    }
}
