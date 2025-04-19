using Microsoft.EntityFrameworkCore;
using Projet5.Data;
using Projet5.Models;
using System.Threading.Tasks;

namespace Projet5.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> GetUserByIdentifiantAsync(string identifiant)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Identifiant == identifiant);
        }

        public async Task<bool> IsUserAdminAsync(string identifiant)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Identifiant == identifiant);
            return user != null && user.EstAdministrateur;
        }

        public async Task AddUserAsync(UserModel user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UserExistsAsync(string identifiant)
        {
            return await _context.Users.AnyAsync(u => u.Identifiant == identifiant);
        }
    }
}
