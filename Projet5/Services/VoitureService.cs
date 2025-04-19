using Projet5.Models;
using Projet5.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projet5.Services
{
    public class VoitureService : IVoitureService
    {
        private readonly IVoitureRepository _voitureRepository;

        public VoitureService(IVoitureRepository voitureRepository)
        {
            _voitureRepository = voitureRepository;
        }

        public async Task<IEnumerable<VoitureModel>> GetAllVoituresAsync()
        {
            return await _voitureRepository.GetAllVoituresAsync();
        }

        public async Task<VoitureModel> GetVoitureByIdAsync(int id)
        {
            return await _voitureRepository.GetVoitureByIdAsync(id);
        }

        public async Task<bool> CreateVoitureAsync(VoitureModel voiture)
        {
            try
            {
                await _voitureRepository.AddVoitureAsync(voiture);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateVoitureAsync(int id, VoitureModel voiture)
        {
            if (id != voiture.Vin)
                return false;

            var exists = await _voitureRepository.VoitureExistsAsync(id);
            if (!exists)
                return false;

            try
            {
                await _voitureRepository.UpdateVoitureAsync(voiture);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteVoitureAsync(int id)
        {
            var exists = await _voitureRepository.VoitureExistsAsync(id);
            if (!exists)
                return false;

            try
            {
                await _voitureRepository.DeleteVoitureAsync(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> VoitureExistsAsync(int id)
        {
            return await _voitureRepository.VoitureExistsAsync(id);
        }

        public async Task<IDictionary<string, object>> GetVoitureStatisticsAsync()
        {
            var totalCount = await _voitureRepository.GetVoitureCountAsync();
            var disponibleCount = await _voitureRepository.GetDisponibleVoitureCountAsync();
            var totalValue = await _voitureRepository.GetTotalVoitureValueAsync();

            return new Dictionary<string, object>
            {
                { "TotalCount", totalCount },
                { "DisponibleCount", disponibleCount },
                { "TotalValue", totalValue }
            };
        }
    }
}
