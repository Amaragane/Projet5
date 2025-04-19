using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projet5.Filters;
using Projet5.Models;
using Projet5.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet5.Controllers
{
    public class VoituresController : Controller
    {
        private readonly IVoitureService _voitureService;

        public VoituresController(IVoitureService voitureService)
        {
            _voitureService = voitureService;
        }

        // GET: Voitures
        public async Task<IActionResult> Index()
        {
            var voitures = await _voitureService.GetAllVoituresAsync();
            return View(voitures);
        }

        // GET: Voitures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _voitureService.GetVoitureByIdAsync(id.Value);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // GET: Voitures/Create
        [Authorize]
        [AdminOnly]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voitures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [AdminOnly]
        public async Task<IActionResult> Create(VoitureModel voiture)
        {
            if (ModelState.IsValid)
            {
                bool success = await _voitureService.CreateVoitureAsync(voiture);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(voiture);
        }

        // GET: Voitures/Edit/5
        [Authorize]
        [AdminOnly]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _voitureService.GetVoitureByIdAsync(id.Value);
            if (voiture == null)
            {
                return NotFound();
            }
            return View(voiture);
        }

        // POST: Voitures/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [AdminOnly]
        public async Task<IActionResult> Edit(int id, VoitureModel voiture)
        {
            if (id != voiture.Vin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool success = await _voitureService.UpdateVoitureAsync(id, voiture);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    if (!await _voitureService.VoitureExistsAsync(voiture.Vin))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "Une erreur s'est produite lors de la mise à jour de ce véhicule.");
                    }
                }
            }
            return View(voiture);
        }

        // GET: Voitures/Delete/5
        [Authorize]
        [AdminOnly]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voiture = await _voitureService.GetVoitureByIdAsync(id.Value);
            if (voiture == null)
            {
                return NotFound();
            }

            return View(voiture);
        }

        // POST: Voitures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        [AdminOnly]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool success = await _voitureService.DeleteVoitureAsync(id);
            if (!success)
            {
                return NotFound();
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Voitures/Admin
        [Authorize]
        [AdminOnly]
        public async Task<IActionResult> Admin()
        {
            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewBag.Statistics = await _voitureService.GetVoitureStatisticsAsync();
            return View(voitures);
        }

        // Méthode supprimée car maintenant gérée par le service
    }
}
