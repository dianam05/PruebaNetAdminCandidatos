using AdminCandidatos.Infrastructure.Models;
using AdminCandidatos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdminCandidatos.Application.Queries.Candidates
{
    // Query DTO


    // Query Handler
    public class GetCandidateByIdQueryHandler
    {
        private readonly AdminCandidatosDBContext _context;

        public GetCandidateByIdQueryHandler(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        public Infrastructure.Models.Candidates? Handle(GetCandidateByIdQuery query)
        {
            return _context.Candidates
                .Include(c => c.Experiences)
                .FirstOrDefault(c => c.IdCandidate == query.IdCandidate);
        }
    }
}
