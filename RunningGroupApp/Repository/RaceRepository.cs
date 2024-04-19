using Microsoft.EntityFrameworkCore;
using RunningGroupApp.Data;
using RunningGroupApp.Data.Interface;
using RunningGroupApp.Models;

namespace RunningGroupApp.Repository
{
    public class RaceRepository : IRaceRepository
    {
        private readonly ApplicationDbContext _context;

        public RaceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Race race)
        {
            _context.Add(race);
            return Save();
        }

        public bool Update(Race race)
        {
            _context?.Update(race);
            return Save();

        }

        public async Task<bool> Delete(Race race)
        {
            _context.Remove(race);
            return Save();
        }

        public async Task<IEnumerable<Race>> GetAllAsync() => await _context.Races.Include(c => c.Address).ToListAsync();

        public async Task<IEnumerable<Race>> GetByCityAsync(string city) => await _context.Races.Where(c => c.Address.City.Contains(city)).ToListAsync();

        public async Task<Race>? GetByIdAsync(int id) => await _context.Races.Include(r => r.Address).FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Race>? GetByIdAsyncNoTracking(int id) => await _context.Races.Include(c => c.Address).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        public bool Save()
        {
            int modified = _context.SaveChanges();
            return modified > 0 ? true : false;
        }

    }
}

