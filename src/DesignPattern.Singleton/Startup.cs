using DesignPattern.Singleton;

public class Startup
{
    public static void Execute()
    {

        //Singleton.Singleton.GetInstance();
        //Singleton.Singleton.GetInstance();
        Console.WriteLine(Singleton.Greetings);
        Singleton.GetInstance();
        Console.ReadKey();
    }
}