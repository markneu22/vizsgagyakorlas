using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanosvenyek_Console
{
    public class Telepules
    {
        public int id { get; private set; }
        public string nev { get; private set; }

        public Telepules(string sor)
        {
            string[] adat = sor.Split(';');
            id = int.Parse(adat[0]);
            nev = adat[1];
        }

        public static List<Telepules> LoadFromCsv(string fileNev)
        {
            List<Telepules> telepulesek = new();
            File.ReadAllLines(fileNev).Skip(1).ToList().ForEach(x => telepulesek.Add(new Telepules(x)));
            return telepulesek;
        }
    }
}
