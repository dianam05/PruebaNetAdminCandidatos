using AdminCandidatos.Application.Commands.Candidates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCandidatos.Application.Interfaces.Candidates
{
    public interface ICreateCandidateCommandHandler
    {
        void Handle(CreateCandidateCommand command);
    }
}
