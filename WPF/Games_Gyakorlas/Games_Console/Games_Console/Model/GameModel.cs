using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games_Console.Model
{
    public class GameModel
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public DateTime Release { get; set; } 
        public double Rate { get; set; }
        public int PublisherId { get; set; }

        public GameModel(string line)
        {
            string[] data = line.Split(';');
            Id = int.Parse(data[0]);
            Name = data[1];
            Release = DateTime.ParseExact(data[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Rate = double.Parse(data[3]);
            PublisherId = int.Parse(data[4]);
        }

        public static List<GameModel> loadGames(string fileName)
        {
            List<GameModel> games = new List<GameModel>();
            try
            {
                StreamReader sr = new StreamReader(fileName);
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    games.Add(new GameModel(sr.ReadLine()));
                }
                sr.Close();
               
            }
            catch(Exception ex)
            {
                Console.WriteLine("Fájl beolvasás sikertelen!\n" +  ex.Message);
            }
            return games;
        }

    }
}
