using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanosvenyek_Console
{
    public class Utvonal
    {
        //azon;nev;hossz;allomas;ido;vezetes;telepulesid
        //1;Anna-ligeti tanösvény;2.0;8;1.5;true;89
        public int azon { get; private set; }
        public string nev { get; private set; }
        public double hossz { get; set; }
        public int allomas { get; private set; }
        public double ido { get; private set; }
        public bool vezetes { get; private set; }
        public int telepulesid { get; private set; }

        public Utvonal(string sor)
        {
            string[] adat = sor.Split(';');
            azon = int.Parse(adat[0]);
            nev = adat[1];
            hossz = double.Parse(adat[2].Replace('.',','));
            allomas = int.Parse(adat[3]);
            ido = double.Parse(adat[4].Replace('.', ','));
            vezetes = bool.Parse(adat[5]);
            telepulesid = int.Parse(adat[6]);
        }

        public static List<Utvonal> LoadFromCsv(string fileNev)
        {
            List<Utvonal> utvonalak = new();
            File.ReadAllLines(fileNev).Skip(1).ToList().ForEach(x => utvonalak.Add(new Utvonal(x)));
            return utvonalak;
        }
    }
}
