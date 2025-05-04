using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VoituresController(IVoitureService voitureService, IWebHostEnvironment webHostEnvironment)
        {
            _voitureService = voitureService;
            _webHostEnvironment = webHostEnvironment;
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
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voitures/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        
        public async Task<IActionResult> Create(VoitureModel voiture, IFormFile ImageUrl)
        {

            if (ModelState.IsValid)
            {
                if(voiture.Marque == voiture.Modele)
                {
                    ModelState.AddModelError("Marque", "La marque et le modèle ne peuvent pas être identiques.");
                    return View(voiture);
                }
                if (ImageUrl != null && ImageUrl.Length > 0)
                {
                    // Générer un nom de fichier unique
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageUrl.FileName);

                    // Déterminer le chemin où sauvegarder l'image
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", "voitures", fileName);

                    // Créer le dossier si nécessaire
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

                    // Sauvegarder l'image
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageUrl.CopyToAsync(stream);
                    }

                    // Stocker le chemin de l'image dans votre modèle
                    voiture.ImageUrl = "/images/voitures/" + fileName;
                }
                bool success = await _voitureService.CreateVoitureAsync(voiture);
                if (success)
                {
                    // Rediriger vers la page de confirmation d'ajout
                    return View("Confirmations/AjoutConfirmation", voiture);
                }
            }
            return View(voiture);
        }

        // GET: Voitures/Edit/5
        [Authorize(Roles ="Admin")]
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
        [Authorize(Roles ="Admin")]
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
        [Authorize(Roles ="Admin")]
        
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
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Récupérer les informations de la voiture avant de la supprimer
            var voiture = await _voitureService.GetVoitureByIdAsync(id);
            if (voiture == null)
            {
                return NotFound();
            }

            try
            {
                string imagePath = voiture.ImageUrl!.TrimStart('/');
                string fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath);
                // Vérifier si le fichier existe avant de le supprimer
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
            catch (Exception ex)
            {
                // Log l'erreur mais continuer la suppression de l'enregistrement
                // Vous pouvez utiliser ILogger ici pour enregistrer l'exception
                Console.WriteLine($"Erreur lors de la suppression de l'image: {ex.Message}");
            }
            bool success = await _voitureService.DeleteVoitureAsync(id);
            if (!success)
            {
                return NotFound();
            }
            
            // Rediriger vers la page de confirmation de suppression
            return View("Confirmations/SuppressionConfirmation",voiture);
        }

        // GET: Voitures/Admin
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Admin()
        {
            var voitures = await _voitureService.GetAllVoituresAsync();
            ViewBag.Statistics = await _voitureService.GetVoitureStatisticsAsync();
            return View(voitures);
        }

        // Méthode supprimée car maintenant gérée par le service
    }
}
