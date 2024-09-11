using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sleep_Tracker.Models;

namespace Sleep_Tracker.Controllers;

public class HomeController : Controller
{
    private ISleepTrackerRepository _repo;

    public HomeController(ISleepTrackerRepository temp)
    {
        _repo = temp;
    }
    
    
    public IActionResult Index()
    {

        var nightList = _repo.Nights.ToList();
        return View(nightList);
    }

    public IActionResult Tonight()
    {
        var latestNightID = _repo.Nights
            .Max(x => x.NightId);

        var latestNight = _repo.Nights
            .FirstOrDefault(x => x.NightId == latestNightID);
        
        var shifts = _repo.Shifts
            .Where(x => x.NightId == latestNightID);

        ViewBag.LatestNight = latestNight;
        ViewBag.Shifts = shifts;
        return View();
        
    }
    
    public IActionResult Night(int id)
    {
        var currentNight = _repo.Nights
            .Single(x => x.NightId == id);

        var currentShifts = _repo.Shifts
            .Where(x => x.NightId == id)
            .Include(x => x.DiaperChanges)
            .ToList();


        ViewBag.CurrentNight = currentNight;
        ViewBag.CurrentShifts = currentShifts;
        
        
        return View();
    }
    [HttpGet]
    public IActionResult AddNight()
    {
        return View("AddNight", new Night());
    }
    
    [HttpPost]
    public IActionResult AddNight(Night response)
    {
        if (ModelState.IsValid)
        {
            _repo.AddNight(response);
            return View("AddNightConfirmation", response);
        }
        else
        {
            return View(response);
        }
    }

    [HttpGet]
    public IActionResult AddShift(int id)
    {
        var currentNight = _repo.Nights
            .FirstOrDefault(x => x.NightId == id);
        
        if (currentNight == null)
        {
            return NotFound();
        }
        
        ViewBag.CurrentNight = currentNight;
        
        var newShift = new Shift { NightId = id };
        
        return View(newShift);
        
    }

    [HttpPost]
    public IActionResult AddShift(Shift response)
    {
        if (ModelState.IsValid)
        {
            _repo.AddShift(response);
            return View("ShiftConfirmation",response);
        }
        else
        {
            return View(response);
        }
    }

    [HttpGet]
    public IActionResult EditShift(int id)
    {
        var shiftToEdit = _repo.Shifts
            .Single(x => x.ShiftId == id);

        return View("EditShift", shiftToEdit);
    }

    [HttpPost]
    public IActionResult EditShift(Shift updatedShift)
    {
        _repo.EditShift(updatedShift);
        return View("ShiftConfirmation",updatedShift);
    }

    [HttpGet]
    public IActionResult AddDiaperChange(int id )
    {
        var currentShift = _repo.Shifts
            .FirstOrDefault(x => x.ShiftId == id);
        
        if (currentShift == null)
        {
            return NotFound();
        }
        
        ViewBag.CurrentShift = currentShift;
        
        var newDiaperChange = new DiaperChange() { ShiftId = id };
        
        return View(newDiaperChange);    
    }

    [HttpPost]
    public IActionResult AddDiaperChange(DiaperChange response)
    {
        if (ModelState.IsValid)
        {
            _repo.AddDiaperChange(response);
            return View("DiaperChangeConfirmation", response);
        }
        else
        {
            return View(response);
        }
    }
    
    public IActionResult Summary()
    {
        return View();
    }
    public IActionResult Settings()
    {
        return View();
    }


   
}