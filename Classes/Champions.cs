using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyMVCapp.Models;

public class Champion
{
    public string name { get; set; }

    public List<Champion> GetChampions()
    {
        var champions = new List<Champion>();
        var client = new HttpClient();
        client.BaseAddress = new Uri("https://ddragon.leagueoflegends.com");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        string version = Util.getLatestVersion();
        HttpResponseMessage response = client.GetAsync("/cdn/" + version + "/data/en_US/champion.json").Result;
        if (response.IsSuccessStatusCode)
        {
            var championsData = response.Content.ReadFromJsonAsync<Champion>().Result;
            if (championsData != null)
            {
                foreach (var champion in championsData.name)
                {
                    //print the champion name
                    Console.WriteLine(champion);
                    //champions.Add(new Champion { name = champion.Key });
                }
            }
        }
        return champions;
    }
}