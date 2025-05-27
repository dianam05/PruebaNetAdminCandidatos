using AdminCandidatos.Application.Commands.Candidates;
using AdminCandidatos.Application.Interfaces.CandidateExperiences;
using AdminCandidatos.Application.Interfaces.Candidates;
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

        private readonly IGetAllCandidatesQueryHandler _getAllHandler;
        private readonly IGetCandidateByIdQueryHandler _getByIdHandler;
        private readonly ICreateCandidateCommandHandler _createHandler;
        private readonly IUpdateCandidateCommandHandler _updateHandler;
        private readonly IDeleteCandidateCommandHandler _deleteHandler;

        private readonly ICreateCandidateExperienceCommandHandler _createExperienceHandler;
        private readonly IUpdateCandidateExperienceCommandHandler _updateExperienceHandler;
        private readonly IDeleteCandidateExperienceCommandHandler _deleteExperienceHandler;

        public CandidateController(
            IGetAllCandidatesQueryHandler getAllHandler,
            IGetCandidateByIdQueryHandler getByIdHandler,
            ICreateCandidateCommandHandler createHandler,
            IUpdateCandidateCommandHandler updateHandler,
            IDeleteCandidateCommandHandler deleteHandler,
            ICreateCandidateExperienceCommandHandler createExperienceHandler,
            IUpdateCandidateExperienceCommandHandler updateExperienceHandler,
            IDeleteCandidateExperienceCommandHandler deleteExperienceHandler)
        {
            _getAllHandler = getAllHandler;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
            _updateHandler = updateHandler;
            _deleteHandler = deleteHandler;
            _createExperienceHandler = createExperienceHandler;
            _updateExperienceHandler = updateExperienceHandler;
            _deleteExperienceHandler = deleteExperienceHandler;
        }

        [HttpGet]
        public IActionResult Search(string name, string email)
        {
            var candidates = _getAllHandler.Handle(name, email);
            return View("Index", candidates);
        }


        // GET: /Candidate/
        public IActionResult Index(string? name, string? email)
        {

            var candidates = _getAllHandler.Handle();
            return View(candidates);
        }

        // GET: /Candidate/Details/5
        public IActionResult Details(int id)
        {
            var handler = new GetCandidateByIdQueryHandler(_context);
            var candidate = _getByIdHandler.Handle(new GetCandidateByIdQuery(id));
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

            _createHandler.Handle(command);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Candidate/Edit/5
        public IActionResult Edit(int id)
        {
            var handler = new GetCandidateByIdQueryHandler(_context);
            var candidate = _getByIdHandler.Handle(new GetCandidateByIdQuery(id));
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
            _updateHandler.Handle(command);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Candidate/Delete/5
        public IActionResult Delete(int id)
        {
            var handler = new GetCandidateByIdQueryHandler(_context);
            var candidate = _getByIdHandler.Handle(new GetCandidateByIdQuery(id));
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
            _deleteHandler.Handle(new DeleteCandidateCommand(id));
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddExperience(int candidateId)
        {
            return RedirectToAction("Create", "CandidateExperience", new { candidateId });
        }


    }
}
