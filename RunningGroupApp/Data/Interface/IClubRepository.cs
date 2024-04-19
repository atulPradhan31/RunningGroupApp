using RunningGroupApp.Models;

namespace RunningGroupApp.Data.Interface
{
    public interface IClubRepository
    {
        Task<IEnumerable<Club>> GetAllAsync();

        Task<Club> GetByIdAsync(int id);

        Task<Club> GetByIdAsyncNoTracking(int id);

        Task<IEnumerable<Club>> GetByCityAsync(string city);

        bool Add(Club club);

        bool Update(Club club);

        Task<bool> Delete(Club club);

        bool Save();

        
    }
}
