// See https://aka.ms/new-console-template for more information

using Games_Console;

var bestGame = Solution.GetBest();
if (bestGame != null)
{
    Console.WriteLine("1.feladat: A legjobbra értékelt játék:");
    Console.WriteLine($"\tNév: {bestGame.Name}");
    Console.WriteLine($"\tMegjelenés éve: {bestGame.Release:yyyy.MM.dd}");
    Console.WriteLine($"\tPontszám: {bestGame.Rate}");
}

var list = Solution.GetPublishersBestRate();
Console.WriteLine("2.feladat: Legjobbra értékelt játékok kiadónként:");
foreach (var item in list)
{
    Console.WriteLine($"\t{item}");
}

Console.WriteLine($"3.feladat:\n{Solution.GetMaxDays()}");