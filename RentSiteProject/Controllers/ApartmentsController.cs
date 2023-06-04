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
        /*// Метод для вывода списка всех квартир
        public IActionResult AllApartmentsList()
        {
            var apartments = _context.Apartments.ToList();
            return View(apartments);
        }*/
        public IActionResult AllApartmentsList(string title, int? minRooms, int? maxRooms, int? minPrice, int? maxPrice)
        {
            var query = _context.Apartments.AsQueryable();

            // Применение фильтра по заголовку (названию) квартиры
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(a => a.Title.Contains(title));
            }

            // Применение фильтра по количеству комнат
            if (minRooms.HasValue)
            {
                query = query.Where(a => a.Rooms >= minRooms.Value);
            }
            if (maxRooms.HasValue)
            {
                query = query.Where(a => a.Rooms <= maxRooms.Value);
            }

            // Применение фильтра по цене
            if (minPrice.HasValue)
            {
                query = query.Where(a => a.Price >= minPrice.Value);
            }
            if (maxPrice.HasValue)
            {
                query = query.Where(a => a.Price <= maxPrice.Value);
            }

            var apartments = query.ToList();
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

        // Метод для отображения подробной информации о квартире
        public IActionResult ApartmentDetails(int id)
        {
            var apartment = _context.Apartments.FirstOrDefault(a => a.Id == id);
            return View(apartment);
        }

        // Метод для отображения страницы редактирования квартиры
        [HttpGet]
        public IActionResult ApartmentsEdit(int id)
        {
            var apartment = _context.Apartments.Find(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return View(apartment);
        }
    }
}
