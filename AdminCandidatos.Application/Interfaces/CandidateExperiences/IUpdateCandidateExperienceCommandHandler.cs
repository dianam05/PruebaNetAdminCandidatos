using AdminCandidatos.Application.Commands.CandidateExperiences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCandidatos.Application.Interfaces.CandidateExperiences
{
    public interface IUpdateCandidateExperienceCommandHandler
    {
        void Handle(UpdateCandidateExperienceCommand command);
    }
}
