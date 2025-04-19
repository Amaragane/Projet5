using Projet5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projet5.Services
{
    public interface IVoitureService
    {
        Task<IEnumerable<VoitureModel>> GetAllVoituresAsync();
        Task<VoitureModel> GetVoitureByIdAsync(int id);
        Task<bool> CreateVoitureAsync(VoitureModel voiture);
        Task<bool> UpdateVoitureAsync(int id, VoitureModel voiture);
        Task<bool> DeleteVoitureAsync(int id);
        Task<bool> VoitureExistsAsync(int id);
        Task<IDictionary<string, object>> GetVoitureStatisticsAsync();
    }
}
