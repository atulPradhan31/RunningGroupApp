using Microsoft.AspNetCore.Mvc;
using RunningGroupApp.Data.Interface;
using RunningGroupApp.Models;

namespace RunningGroupApp.Controllers
{
    public class ClubController : Controller
    {
        private readonly IClubRepository _clubRepository;
        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Club> clubs = await _clubRepository.GetAllAsync();
            return View(clubs);
        }

        public async Task<IActionResult> Details(int id) 
        {
            Club? club =  await _clubRepository.GetByIdAsync(id);
            return View(club);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Club club)
        {
            if(!ModelState.IsValid)
            {
                return View(club);
            }

            _clubRepository.Add(club);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Club? club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Club club)
        {
            if(!ModelState.IsValid)
                return View(club);

             _clubRepository.Update(club);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Club? club = await _clubRepository.GetByIdAsync(id);
            return View(club);
        }

        [HttpPost, ActionName("Delete")]
        public  async Task<IActionResult> DeleteClub(int id)
        {
            Club? club = await _clubRepository.GetByIdAsyncNoTracking(id);
            _clubRepository.Delete(club);
            return RedirectToAction("Index");
        }

    }
}
