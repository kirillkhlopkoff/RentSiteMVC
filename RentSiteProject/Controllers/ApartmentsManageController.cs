﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentSiteProject.Data;
using RentSiteProject.Models;
using RentSiteProject.Models.Users;

namespace RentSiteProject.Controllers
{
    public class ApartmentsManageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ApartmentsManageController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Метод для вывода списка всех квартир // исправить на вывод квартир данного пользователя
        public IActionResult Index()
        {
            var apartments = _context.Apartments.ToList();
            return View(apartments);
        }

        // Метод для создания новой квартиры (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Метод для создания квартиры (POST)
        [HttpPost]
        public async Task<ActionResult<Apartment>> Create(Apartment apartment)
        {
            // Получение текущего пользователя
            User currentUser = _userManager.GetUserAsync(HttpContext.User).Result;

            // Присвоение UserId квартире
            apartment.UserId = currentUser.Id;
            apartment.Author = currentUser.FirstName;

            // Другая логика сохранения квартиры в базе данных
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyApartments", "Apartments");
        }

        // Метод для редактирования квартиры (GET)
        public IActionResult Edit(int id)
        {
            var apartment = _context.Apartments.Find(id);
            if (apartment == null)
            {
                return NotFound();
            }
            return View(apartment);
        }

        // Метод для редактирования квартиры (POST)
        [HttpPost]
        public IActionResult Edit(Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                _context.Apartments.Update(apartment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apartment);
        }

        // Метод для удаления квартиры
        public IActionResult Delete(int id)
        {
            var apartment = _context.Apartments.Find(id);
            if (apartment == null)
            {
                return NotFound();
            }
            _context.Apartments.Remove(apartment);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
