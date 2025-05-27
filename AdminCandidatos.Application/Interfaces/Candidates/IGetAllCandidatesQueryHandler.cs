using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCandidatos.Application.Interfaces.Candidates
{
    public interface IGetAllCandidatesQueryHandler
    {
        List<Infrastructure.Models.Candidates> Handle();

        IEnumerable<Infrastructure.Models.Candidates> Handle(string name = null, string email = null);
    }
}
