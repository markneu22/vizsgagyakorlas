using Games_Console.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games_Console
{
    public static class Solution
    {
        public static List<GameModel> games { get; set; } = GameModel.loadGames("games.csv");
        public static List<PublisherModel> publishers { get; set; } = PublisherModel.loadPusblihshers("publishers.csv");

        public static GameModel? GetBest() => games.Where(x => x.Rate == games.Max(y => y.Rate)).FirstOrDefault();
        
        public static List<string> GetPublishersBestRate()
        {
            List<string> results = new List<string>();
            foreach (var publisher in publishers)
            {
                var publishersGames = games.Where(x => x.PublisherId == publisher.Id).ToList();
                var game = publishersGames.Where(x => x.Rate == publishersGames.Max(y => y.Rate)).FirstOrDefault();
                if(game != null)
                    results.Add($"{publisher.CompanyName}: {game.Name} - Pontszám: {game.Rate}");
            }
            return results;
        }

        public static string GetMaxDays()
        {
            Dictionary<string, int> days = new Dictionary<string, int>();
            foreach (var publisher in publishers)
            {
                var publishersGames = games.Where(x => x.PublisherId == publisher.Id).OrderBy(x => x.Release).ToList();
                int max = 0;
                for (int i = 0; i < publishersGames.Count-1; i++)
                {
                    if ((publishersGames[i + 1].Release - publishersGames[i].Release).TotalDays > max)
                        max = (publishersGames[i + 1].Release - publishersGames[i].Release).Days;
                }
                days.Add(publisher.CompanyName, max);
            }
            var result =  days.Where(x => x.Value == days.Max(x => x.Value)).First();
            return $"\tKiadó: {result.Key}\n\tEltelt napok száma: {result.Value}";
        }

    }
}
