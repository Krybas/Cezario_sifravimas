using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Iveskite zodi: ");
        string zodis = Console.ReadLine();

        Console.WriteLine("Iveskite poslinki: ");
        int poslinkis = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Pasirinkite numerį: \n" + "1. Su masyvu \n" + "2. Su ascii");
        int pasirinkimas = Convert.ToInt32(Console.ReadLine());

        string uzsifruotasZodis = uzsifvravimas(zodis, poslinkis, pasirinkimas);

        string issifruotasZodis = issivravimas(uzsifruotasZodis, poslinkis, pasirinkimas);

        Console.WriteLine("Žodis: " + zodis);
        Console.WriteLine("Poslinkis: " + poslinkis);
        Console.WriteLine("pasirinkimas: " + pasirinkimas);
        Console.WriteLine("Užšifruotas Žodis: " + uzsifruotasZodis);
        Console.WriteLine("Iššifruotas Žodis: " + issifruotasZodis);
    }

    static string uzsifvravimas(string zodis, int poslinkis, int pasirinkimas)
    {
        switch(pasirinkimas)
        {
            case 1:
                return arrayCezaris(zodis, poslinkis);
            case 2:
                return asciiCezaris(zodis, poslinkis); 
            default:
                Console.WriteLine("Nežinomas pasirkimas: " + pasirinkimas);
                Environment.Exit(0);
                return null;
        }
        
    }

    static string issivravimas(string zodis, int poslinkis, int pasirinkimas)
    {
        switch (pasirinkimas)
        {
            case 1:
                return arrayCezaris(zodis, -poslinkis);
            case 2:
                return asciiCezaris(zodis, -poslinkis);
            default:
                Console.WriteLine("Nežinomas pasirkimas: " + pasirinkimas);
                Environment.Exit(0);
                return null;
        }
    }

    static string arrayCezaris(string zodis, int poslinkis)
    {
        string abecele = "aąbcčdeęėfghiįyjklmnoprsštuųūvzž" +
                         "AĄBCČDEĘĖFGHIĮYJKLMNOPRSŠTUŲŪVZŽ" +
                         "0123456789";
        char[] uzsifruotas = zodis.ToCharArray();
        for (int i = 0; i < uzsifruotas.Length; i++)
        {
            int indeksas = abecele.IndexOf(uzsifruotas[i]);
            if (indeksas != -1)
            {
                uzsifruotas[i] = abecele[(indeksas + poslinkis) % abecele.Length];
            }
                
        }
        return new string(uzsifruotas);
    }
    static string asciiCezaris(string uzsifruotas, int poslinkis)
    {
        char[] zodzioRaides = uzsifruotas.ToCharArray();
        for (int i = 0; i < zodzioRaides.Length; i++)
        {
            int ascii = (int)zodzioRaides[i];
            zodzioRaides[i] = (char)(ascii + poslinkis % 256);
        }
        return new string(zodzioRaides);
    }
}