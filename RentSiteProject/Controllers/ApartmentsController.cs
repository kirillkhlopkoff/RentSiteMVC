using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentSiteProject.Data;
using RentSiteProject.Models.Users;

namespace RentSiteProject.Controllers
{
    public class ApartmentsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ApartmentsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // Метод для вывода списка всех квартир
        public IActionResult AllApartmentsList()
        {
            var apartments = _context.Apartments.ToList();
            return View(apartments);
        }


        // Метод для отображения страницы своих квартир
        [HttpGet]
        public async Task<IActionResult> MyApartments()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var userApartments = _context.Apartments.Where(a => a.UserId == currentUser.Id).ToList();
            return View(userApartments);
        }
    }
}
