using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMVCapp.Models;
using Champions;
namespace MyMVCapp.Controllers;

public class SummonerController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public SummonerController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("Summoner")]
    [Route("Summoner/Index")]
    public ActionResult Index()
    {
        return View();
    }
    [Route("Summoner/{id}")]
    public ActionResult Index(string id)
    {
        // string str = string.Format
        // ("The id passed as parameter is: {0}", id);
        return View(new SummonerModel { puuid = id });
    }

}