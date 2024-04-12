using CarShowRoom.Data;
using CarShowRoom.Models;
using CarShowRoom.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Controllers
{
    public class AddCarController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AddCarController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Read()
        {
            var mycar = await _context.Cars.ToListAsync();
            return View(mycar);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddCar Car)
        {
            if (ModelState.IsValid)
            {
                var mycar = new Cars();
                mycar.Name = Car.Name;
                mycar.Year = Car.Year;
                mycar.HorsePower = Car.HorsePower;
                await _context.Cars.AddAsync(mycar);
                await _context.SaveChangesAsync();

            }
            return RedirectToAction("Create");


        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {

            var car = await _context.Cars.FindAsync(Id);
            return View(car);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cars Car)
        {
            if (ModelState.IsValid)
            {
                var mycar = await _context.Cars.FirstOrDefaultAsync(c => c.Id == Car.Id);
                mycar.Name = Car.Name;
                mycar.Year = Car.Year;
                mycar.HorsePower = Car.HorsePower;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Read");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var mycar = await _context.Cars.FirstOrDefaultAsync(c => c.Id == c.Id);
            if (mycar != null)
            {
                _context.Cars.Remove(mycar);
                await _context.SaveChangesAsync();
                return RedirectToAction("Read");
            }
            return NotFound();
        }

    }
}

