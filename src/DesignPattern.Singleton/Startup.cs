using DesignPattern.Singleton;

public class Startup
{
    public static void Run()
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        //Singleton.Singleton.GetInstance();
        //Singleton.Singleton.GetInstance();

        Console.WriteLine(Singleton.Greetings);
        Console.ReadKey();
    }
}