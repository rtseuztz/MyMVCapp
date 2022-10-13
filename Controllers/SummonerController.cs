using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMVCapp.Models;
using Champions;
using sqltest;
using System.Data;
using Summoners;
using Games;
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
    public async Task<ActionResult> Index(string id)
    {
        //this way it will work even if the user in the db switches names
        Summoner? summoner = Summoner.GetSummoner(id);

        if (summoner == null)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        // update the database
        summoner.updateUploadSummoner();

        //retrieve the user's games
        List<Games.Games> games = await Games.Games.getGames(summoner.Puuid);
        var wr = await summoner.winRate();
        return View(new SummonerModel { puuid = summoner.Name, wr = wr, games = games });
    }

}