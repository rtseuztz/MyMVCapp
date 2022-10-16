using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMVCapp.Models;
using Champions;
namespace MyMVCapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string? x)
    {
        Console.WriteLine(x);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Champions()
    {
        // var champions = new Champion();
        var championList = Champion.ReloadChampions();
        return View();
    }

    public IActionResult Leaderboard()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
