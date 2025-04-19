using Microsoft.EntityFrameworkCore;
using Projet5.Data;
using Projet5.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet5.Repositories
{
    public class VoitureRepository : IVoitureRepository
    {
        private readonly ApplicationDbContext _context;

        public VoitureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VoitureModel>> GetAllVoituresAsync()
        {
            return await _context.Voitures.ToListAsync();
        }

        public async Task<VoitureModel> GetVoitureByIdAsync(int id)
        {
            return await _context.Voitures.FindAsync(id);
        }

        public async Task<bool> VoitureExistsAsync(int id)
        {
            return await _context.Voitures.AnyAsync(v => v.Vin == id);
        }

        public async Task AddVoitureAsync(VoitureModel voiture)
        {
            await _context.Voitures.AddAsync(voiture);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVoitureAsync(VoitureModel voiture)
        {
            _context.Voitures.Update(voiture);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVoitureAsync(int id)
        {
            var voiture = await _context.Voitures.FindAsync(id);
            if (voiture != null)
            {
                _context.Voitures.Remove(voiture);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetVoitureCountAsync()
        {
            return await _context.Voitures.CountAsync();
        }

        public async Task<int> GetDisponibleVoitureCountAsync()
        {
            return await _context.Voitures.CountAsync(v => v.EstDisponible);
        }

        public async Task<decimal> GetTotalVoitureValueAsync()
        {
            // Conversion en decimal pour éviter des problèmes potentiels avec la somme de grands nombres
            return await _context.Voitures.SumAsync(v => (decimal)v.PrixAchat);
        }
    }
}
