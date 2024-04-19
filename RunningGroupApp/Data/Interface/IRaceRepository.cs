using RunningGroupApp.Models;

namespace RunningGroupApp.Data.Interface
{
    public interface IRaceRepository
    {
            Task<IEnumerable<Race>> GetAllAsync();

            Task<Race> GetByIdAsync(int id);

            Task<Race> GetByIdAsyncNoTracking(int id);

            Task<IEnumerable<Race>> GetByCityAsync(string city);

            bool Add(Race race);

            bool Update(Race race);

            Task<bool> Delete(Race race);

            bool Save();
    
    }
}
