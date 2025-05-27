using AdminCandidatos.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCandidatos.Application.Interfaces.Candidates
{
    public interface IGetCandidateByIdQueryHandler
    {
        Infrastructure.Models.Candidates Handle(GetCandidateByIdQuery query);
    }
}
