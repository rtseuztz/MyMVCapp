namespace MyMVCapp.Models;

public class SummonerModel
{
    public string? puuid { get; set; }
    public double? wr { get; set; }
    public string summonerName { get; set; } = "";
    public List<Games.Games> games { get; set; } = new List<Games.Games>();
    public void updateSummonerName(string name)
    {
        summonerName = name;
    }
    public void x()
    {

    }
    //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
