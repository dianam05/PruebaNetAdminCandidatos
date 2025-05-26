using AdminCandidatos.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCandidatos.Application.Commands.Candidates
{
    public class DeleteCandidateCommand
    {
        public int IdCandidate { get; set; }

        public DeleteCandidateCommand(int idCandidate)
        {
            IdCandidate = idCandidate;
        }
    }
}
