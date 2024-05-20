namespace Tanosvenyek_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Utvonal> utvonalak = Utvonal.LoadFromCsv("utak.csv");
            List<Telepules> telepulesek = Telepules.LoadFromCsv("telepulesek.csv");


            HashSet<string> utak = utvonalak.Where(x => x.nev.ToLower().Contains("hegy") ||
                                                        x.nev.ToLower().Contains("völgy"))
                                            .Select(x => x.nev)
                                            .ToHashSet();

            Console.WriteLine("6. feladat: Összesen {0} tanösvény van, melynek neve tartalmazza a hegy vagy völgy szót, ezek az alábbiak:",
                utak.Count);
            foreach (var item in utak)
            {
                Console.WriteLine("\t{0}",item);
            }
            Console.WriteLine("7. feladat: Útvonalak településenként:");
            foreach (var item in telepulesek)
            {
                int utvonalDb = utvonalak.Count(x => x.telepulesid == item.id);
                if (utvonalDb >= 3)
                {
                    double leghosszabb = utvonalak.Where(x => x.telepulesid == item.id)
                                               .Where(x => x.hossz == utvonalak.Where(x => x.telepulesid == item.id).Max(y => y.hossz)).First().hossz;
                    Console.WriteLine("\t{0}: {1} db útvonal található - leghosszabb: {2} km",
                        item.nev, utvonalDb, leghosszabb);
                }
            }
        }
    }
}