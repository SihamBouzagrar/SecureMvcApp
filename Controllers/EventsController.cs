using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureMvcApp.Data;
using SecureMvcApp.Models;
public class EventsController : Controller
{
    private readonly ApplicationDbContext _context;

    public EventsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var events = _context.Events.ToList();
        return View(events);
    }

    public IActionResult Details(int id)
    {
        var ev = _context.Events
            .Include(e => e.Inscriptions)
            .FirstOrDefault(e => e.Id == id);

        if (ev == null)
            return NotFound();

        return View(ev);
    }

    [Authorize]
    public IActionResult Register(int eventId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var ev = _context.Events
            .Include(e => e.Inscriptions)
            .FirstOrDefault(e => e.Id == eventId);

        if (ev == null)
            return NotFound();

        var exists = _context.Inscriptions
            .Any(i => i.EventId == eventId && i.UserId == userId);

        if (exists)
            return BadRequest("Déjà inscrit");

        if (ev.Inscriptions.Count >= ev.NombrePlaces)
            return BadRequest("Complet");

        var inscription = new Inscription
        {
            EventId = eventId,
            UserId = userId
        };

        _context.Inscriptions.Add(inscription);
        _context.SaveChanges();

        return RedirectToAction("Details", new { id = eventId });
    }
}