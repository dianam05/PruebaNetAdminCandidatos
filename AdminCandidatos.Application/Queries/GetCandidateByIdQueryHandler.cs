using AdminCandidatos.Application.Interfaces.Candidates;
using AdminCandidatos.Infrastructure.Models;
using AdminCandidatos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AdminCandidatos.Application.Queries.Candidates
{
    public class GetCandidateByIdQueryHandler : IGetCandidateByIdQueryHandler
    {
        private readonly AdminCandidatosDBContext _context;

        public GetCandidateByIdQueryHandler(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        public Infrastructure.Models.Candidates Handle(GetCandidateByIdQuery query)
        {
            return _context.Candidates
                .Include(c => c.Experiences)
                .FirstOrDefault(c => c.IdCandidate == query.IdCandidate);
        }

    }
}
