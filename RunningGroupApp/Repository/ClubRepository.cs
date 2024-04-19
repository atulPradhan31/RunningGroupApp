using Microsoft.EntityFrameworkCore;
using RunningGroupApp.Data;
using RunningGroupApp.Data.Interface;
using RunningGroupApp.Models;

namespace RunningGroupApp.Repository
{
    public class ClubRepository : IClubRepository
    {

        private readonly ApplicationDbContext _context;

        public ClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Club club)
        {
            _context.Add(club);
            return Save();
        }

        public bool Update(Club club)
        {
            _context?.Update(club);
            return Save();

        }

        public async Task<bool> Delete(Club club)
        {
            _context.Remove(club);
            return Save();

        }

        public async Task<IEnumerable<Club>> GetAllAsync() => await _context.Clubs.Include(c => c.Address).ToListAsync();

        public async Task<IEnumerable<Club>> GetByCityAsync(string city) => await _context.Clubs.Where(c => c.Address.City.Contains(city)).ToListAsync();

        public async Task<Club>? GetByIdAsync(int id) => await _context.Clubs.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Club>? GetByIdAsyncNoTracking(int id) => await _context.Clubs.Include(c => c.Address).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        public bool Save()
        {
            int modified = _context.SaveChanges();
            return modified > 0 ? true : false;
        }


    }
}
