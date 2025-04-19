using Projet5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projet5.Repositories
{
    public interface IVoitureRepository
    {
        Task<IEnumerable<VoitureModel>> GetAllVoituresAsync();
        Task<VoitureModel> GetVoitureByIdAsync(int id);
        Task<bool> VoitureExistsAsync(int id);
        Task AddVoitureAsync(VoitureModel voiture);
        Task UpdateVoitureAsync(VoitureModel voiture);
        Task DeleteVoitureAsync(int id);
        Task<int> GetVoitureCountAsync();
        Task<int> GetDisponibleVoitureCountAsync();
        Task<decimal> GetTotalVoitureValueAsync();
    }
}
