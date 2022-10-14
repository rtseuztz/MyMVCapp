using Games;
using Summoners;
namespace MyMVCapp.Models;

public class SummonerModel
{
    public Summoner summoner { get; set; }
    public string puuid { get; set; }
    public string summonerName { get; set; } = "";
    public double wr { get; set; }
    public List<Games.Games> gamesList { get; set; } = new List<Games.Games>();
    //constructor
    public SummonerModel(Summoner summoner, List<Games.Games> games)
    {
        this.summoner = summoner;
        this.gamesList = games;
        this.puuid = summoner.Puuid;
        this.summonerName = summoner.Name;
        this.wr = calcwr();
    }

    public void updateSummonerName(string name)
    {
        summonerName = name;
    }
    public double calcwr()
    {
        // calculate winrate
        double wins = 0;
        double games = 0;
        foreach (var game in gamesList)
        {
            List<Participant> participants = game.participants;
            Participant summoner = participants.Find(x => x.puuid == puuid);
            if (summoner.win)
            {
                wins++;
            }
            games++;
        }
        return Math.Round(wins / games * 100, 2);
    }
    //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
