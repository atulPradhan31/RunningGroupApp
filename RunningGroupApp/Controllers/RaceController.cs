using Microsoft.AspNetCore.Mvc;
using RunningGroupApp.Data.Interface;
using RunningGroupApp.Models;
using RunningGroupApp.Repository;

namespace RunningGroupApp.Controllers
{
    public class RaceController : Controller
    {
        private readonly IRaceRepository _raceRepository;

        public RaceController(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Race> races = await _raceRepository.GetAllAsync();
            return View(races);
        }

        public async Task<IActionResult> Details(int id)
        {
            Race? race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Race race)
        {
            if(!ModelState.IsValid)
                return View(race);
            _raceRepository.Add(race);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Race? race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Race race)
        {
            if (!ModelState.IsValid)
                return View(race);

            _raceRepository.Update(race);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Race? race = await _raceRepository.GetByIdAsync(id);
            return View(race);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            Race? race = await _raceRepository.GetByIdAsyncNoTracking(id);
            _raceRepository.Delete(race);
            return RedirectToAction("Index");
        }
    }
}
