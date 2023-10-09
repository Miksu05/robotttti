
public interface IRobottiKäsky
{
    void Suorita(Robotti robotti);
}

public class Robotti
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool OnKäynnissä { get; set; }
    public IRobottiKäsky[] Käskyt { get; } = new IRobottiKäsky[3];

    public void Suorita()
    {
        foreach (IRobottiKäsky käsky in Käskyt)
        {
            käsky.Suorita(this);
            Console.WriteLine($"[{X} {Y} {OnKäynnissä}]");
        }
    }
}

public class Käynnistä : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        robotti.OnKäynnissä = true;
    }
}

public class Sammuta : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        robotti.OnKäynnissä = false;
    }
}

public class YlösKäsky : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.Y++;
        }
    }
}

public class AlasKäsky : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.Y--;
        }
    }
}

public class VasenKäsky : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.X--;
        }
    }
}

public class OikeaKäsky : IRobottiKäsky
{
    public void Suorita(Robotti robotti)
    {
        if (robotti.OnKäynnissä)
        {
            robotti.X++;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Robotti robotti = new Robotti();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Syötä käsky (Käynnistä, Sammuta, Ylös, Alas, Vasen, Oikea):");
            string käskyNimi = Console.ReadLine();

            IRobottiKäsky käsky;

            switch (käskyNimi.ToLower())
            {
                case "käynnistä":
                    käsky = new Käynnistä();
                    break;
                case "sammuta":
                    käsky = new Sammuta();
                    break;
                case "ylös":
                    käsky = new YlösKäsky();
                    break;
                case "alas":
                    käsky = new AlasKäsky();
                    break;
                case "vasen":
                    käsky = new VasenKäsky();
                    break;
                case "oikea":
                    käsky = new OikeaKäsky();
                    break;
                default:
                    Console.WriteLine("Tuntematon käsky, yritä uudelleen.");
                    i--;
                    continue;
            }

            robotti.Käskyt[i] = käsky;
        }

        robotti.Suorita();

        Console.WriteLine("Robotti suoritti käskyt.");
    }
}