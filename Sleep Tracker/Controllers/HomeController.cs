using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sleep_Tracker.Models;

namespace Sleep_Tracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Night()
    {
        return View();
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