namespace MyMVCapp.Models;

public class SummonerModel
{
    public string? puuid { get; set; }

    public string getPuuid => puuid ?? "No puuid";
    //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
