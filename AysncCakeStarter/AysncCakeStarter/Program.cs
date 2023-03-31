using System;
using System.Threading;
using System.Threading.Tasks;

namespace AysncCake;

class Program
{
    public async static Task Main(string[] args)
    {
        Console.WriteLine("Welcome to my birthday homework-section party");
        await HaveAPartyAsync();
        Console.WriteLine("Thanks for a lovely party");
        Console.ReadLine();
    }

    private async static Task BeerCodingAsync()
    {
        Console.WriteLine("Let's have some drinks and then do our homework!");
        await Task.Delay(TimeSpan.FromSeconds(8));
        Console.WriteLine("Let's find someone else to do the work instead!");
        await Task.Delay(TimeSpan.FromSeconds(1));
        FindSomeone("Cormac");
    }

    private static void FindSomeone(string name)
    {
        Console.WriteLine($"{name} is here!");
    }

    private async static Task HaveAPartyAsync()
    {
        var name = "Cathy";
        var cakeTask = BakeCakeAsync();
        BeerCodingAsync();
        PlayPartyGames();
        OpenPresents();
        var cake = await cakeTask;
        Console.WriteLine($"Happy birthday, {name}, {cake}!!");
    }

    private async static Task<Cake> BakeCakeAsync()
    {
        Console.WriteLine("Cake is in the oven");
        await Task.Delay(TimeSpan.FromSeconds(5));
        //Thread.Sleep(TimeSpan.FromSeconds(5));
        Console.WriteLine("Cake is done");
        return new Cake();
    }

    private static void PlayPartyGames()
    {
        Console.WriteLine("Starting games");
        Thread.Sleep(TimeSpan.FromSeconds(2));
        Console.WriteLine("Finishing Games");
    }

    private static void OpenPresents()
    {
        Console.WriteLine("Opening Presents");
        Thread.Sleep(TimeSpan.FromSeconds(1));
        Console.WriteLine("Finished Opening Presents");
    }
}

public class Cake
{
    public override string ToString()
    {
        return "Here's a cake";
    }
}
