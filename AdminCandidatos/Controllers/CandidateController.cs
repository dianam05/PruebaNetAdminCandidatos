using AdminCandidatos.Application.Commands.Candidates;
using AdminCandidatos.Application.Queries;
using AdminCandidatos.Application.Queries.Candidates;
using AdminCandidatos.Infrastructure;
using AdminCandidatos.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MiAppWeb.Controllers
{
    public class CandidateController : Controller
    {
        private readonly AdminCandidatosDBContext _context;

        public CandidateController(AdminCandidatosDBContext context)
        {
            _context = context;
        }

        // GET: /Candidate/
        public IActionResult Index(string? name, string? email)
        {
            var handler = new GetAllCandidatesQueryHandler(_context);
            var query = new GetAllCandidatesQuery
            {
                Name = name,
                Email = email
            };

            var candidates = handler.Handle(query);
            return View(candidates);
        }

        // GET: /Candidate/Details/5
        public IActionResult Details(int id)
        {
            var handler = new GetCandidateByIdQueryHandler(_context);
            var candidate = handler.Handle(new GetCandidateByIdQuery(id));
            if (candidate == null)
                return NotFound();

            return View(candidate);
        }

        // GET: /Candidate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Candidate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateCandidateCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var handler = new CreateCandidateCommandHandler(_context);
            handler.Handle(command);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Candidate/Edit/5
        public IActionResult Edit(int id)
        {
            var handler = new GetCandidateByIdQueryHandler(_context);
            var candidate = handler.Handle(new GetCandidateByIdQuery(id));
            if (candidate == null)
                return NotFound();

            // Convertir entidad a comando para la vista
            var command = new UpdateCandidateCommand
            {
                IdCandidate = candidate.IdCandidate,
                Name = candidate.Name,
                Surname = candidate.Surname,
                Birthdate = candidate.Birthdate,
                Email = candidate.Email,
                Experiences = (List<AdminCandidatos.Infrastructure.Models.CandidateExperience>)candidate.Experiences
            };

            return View(command);
        }

        // POST: /Candidate/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateCandidateCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var handler = new UpdateCandidateCommandHandler(_context);
            handler.Handle(command);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Candidate/Delete/5
        public IActionResult Delete(int id)
        {
            var handler = new GetCandidateByIdQueryHandler(_context);
            var candidate = handler.Handle(new GetCandidateByIdQuery(id));
            if (candidate == null)
                return NotFound();

            return View(candidate);
        }

        // POST: /Candidate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var handler = new DeleteCandidateCommandHandler(_context);
            handler.Handle(new DeleteCandidateCommand(id));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddExperience(int candidateId)
        {
            return RedirectToAction("Create", "CandidateExperience", new { candidateId });
        }


    }
}
