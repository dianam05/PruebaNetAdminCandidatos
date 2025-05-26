using AdminCandidatos.Application.Commands.CandidateExperiences;
using AdminCandidatos.Application.Handlers.CandidateExperiences;
using AdminCandidatos.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace AdminCandidatos.Controllers
{
    public class CandidateExperienceController : Controller
    {
        private readonly AdminCandidatosDBContext _context;

        public CandidateExperienceController(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        // GET: /CandidateExperience/Create?candidateId=5
        public IActionResult Create(int candidateId)
        {
            var command = new CreateCandidateExperienceCommand
            {
                IdCandidate = candidateId
            };
            return View(command);
        }

        // POST: /CandidateExperience/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCandidateExperienceCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var handler = new CreateCandidateExperienceCommandHandler(_context);
            handler.Handle(command);
            return RedirectToAction("Details", "Candidate", new { id = command.IdCandidate });
        }


        // GET: /CandidateExperience/Edit/5
        public IActionResult Edit(int id)
        {
            var exp = _context.CandidateExperience.FirstOrDefault(e => e.IdCandidateExperience == id);
            if (exp == null)
                return NotFound();

            var command = new UpdateCandidateExperienceCommand
            {
                IdCandidateExperience = exp.IdCandidateExperience,
                IdCandidate = exp.IdCandidate,
                Company = exp.Company,
                Job = exp.Job,
                Description = exp.Description,
                Salary = exp.Salary
                //BeginDate = exp.BeginDate,
                //EndDate = exp.EndDate
            };

            return View(command);
        }

        // POST: /CandidateExperience/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateCandidateExperienceCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var handler = new UpdateCandidateExperienceCommandHandler(_context);
            handler.Handle(command);
            return RedirectToAction("Details", "Candidate", new { id = command.IdCandidate });
        }


        // GET: /CandidateExperience/Delete/5
        public IActionResult Delete(int id)
        {
            var experience = _context.CandidateExperience.FirstOrDefault(e => e.IdCandidateExperience == id);
            if (experience == null)
                return NotFound();

            return View(experience);
        }

        // POST: /CandidateExperience/DeleteConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, int idCandidate)
        {
            var handler = new DeleteCandidateExperienceCommandHandler(_context);
            handler.Handle(new DeleteCandidateExperienceCommand { IdCandidateExperience = id });

            return RedirectToAction("Details", "Candidate", new { id = idCandidate });
        }




    }
}
