using System;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Įveskite žodį: ");
        string zodis = Console.ReadLine();

        Console.WriteLine("Įveskite poslinkį: ");
        int poslinkis = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Pasirinkite Cezario šivravimo būdo numerį: \n" + "1. Su masyvu \n" + "2. Su ASCII");
        int pasirinkimas = Convert.ToInt32(Console.ReadLine());

        string uzsifruotasZodis = uzsifvravimas(zodis, poslinkis, pasirinkimas);

        string issifruotasZodis = issivravimas(uzsifruotasZodis, poslinkis, pasirinkimas);

        Console.WriteLine("Žodis: " + zodis);
        Console.WriteLine("Pasirinktas būdas: " + pasirinkimas);
        Console.WriteLine("Poslinkis: " + poslinkis);
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
                return asciiDesifravimas(zodis, poslinkis);
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
        char[] zodisArray = zodis.ToCharArray();
        for (int i = 0; i < zodisArray.Length; i++)
        {
            int indeksas = abecele.IndexOf(zodisArray[i]);
            if (indeksas != -1)
            {
                int newIndeksas = (indeksas + poslinkis) % abecele.Length;
                if (newIndeksas < 0)
                {
                    newIndeksas += abecele.Length;
                }
                zodisArray[i] = abecele[newIndeksas];
            }
        }
        return new string(zodisArray);
    }
    static string asciiCezaris(string zodis, int poslinkis)
    {
        char[] zodisArray = zodis.ToCharArray();
        string rezultatas = "";
        for (int i = 0; i < zodisArray.Length; i++)
        {
            int ASCII = (int)zodisArray[i];

            if (ASCII >= 32 && ASCII <= 127)
            {
                ASCII = ((ASCII - 32 + poslinkis) % 95) + 32; 
                rezultatas += (char)ASCII;
            }
        }
        return rezultatas;
    }
    static string asciiDesifravimas (string zodis, int poslinkis)
    {
        return asciiCezaris(zodis, 95 - poslinkis % 95);
    }
}