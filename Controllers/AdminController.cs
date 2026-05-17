using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMvcApp.Data;
using SecureMvcApp.Models;
namespace SecureMvcApp.Controllers
{
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ✅ POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event ev)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(ev);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ev);
        }

        // (optionnel)
        public IActionResult Index()
        {
            var events = _context.Events.ToList();
            return View(events);
        }
}}
