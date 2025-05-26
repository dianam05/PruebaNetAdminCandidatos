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
    public class GetCandidateByIdQuery
    {
        public int IdCandidate { get; }

        public GetCandidateByIdQuery(int idCandidate)
        {
            IdCandidate = idCandidate;
        }
    }
}
