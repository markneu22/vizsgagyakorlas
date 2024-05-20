using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games_GUI.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Release { get; set; }
        public double Rate { get; set; }
        public int PublisherId { get; set; }
        public GameModel Publisher { get; set; }


    }
}
