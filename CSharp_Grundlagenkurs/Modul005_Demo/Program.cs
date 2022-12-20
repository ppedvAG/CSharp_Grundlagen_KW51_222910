using System.Reflection.Metadata.Ecma335;

namespace Modul005_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Aufruf der Addiere(dbl,dbl)-Funktion
            double summe = Addiere(12.5, 22.5);
            Console.WriteLine(summe);


            //Aufruf der Params-Funktion
            BildeSumme(2, 3, 4);
            BildeSumme(4, 8, 5, 7, 34, 22, 12);




            Subtrahieren(11, 12, 13, 14);
            Subtrahieren(11, 12, 13); //d = 0
            Subtrahieren(11, 12); //c=0 und d=0

        }

        //Jede Funktion/Methode besteht aus einem Kopf und einem Körper
        ///Der Kopf besteht aus den MODIFIERN (public static), dem RÜCKGABEWERT (int), dem NAMEN (Addiere) sowie den ÜBERGABEPARAMETERN
        static int Addiere(int a, int b)
        {
            //Der RETURN-Befehl weist die Methode an einen Wert als Rückgabewert an den Aufrufe zurückzugeben
            return a + b;
        }

        static double Addiere(double a, double b)
            => a+ b;



        //Das PARAMS-Stichwort erlaubt die Übergabe einer beliebige Anzahl von gleichartigen Daten, welche innerhalb
        //der Methode als Array interpretiert werden
        static int BildeSumme(params int[] summanden)
        {
            int summe = 0;

            foreach (int summand in summanden)
            {
                summe += summand;
            }

            return summe;
        }


        ///Wird einem Parameter mittels =-Zeichen ein Defaultwert zugewiesen wird dieser Parameter OPTIONAL und muss bei Aufruf nicht zwangs-
        ///läufig mitgegeben werden. OPTIONALE Parameter müssen am Ende der Parameter stehen.
        static int Subtrahieren (int a, int b, int c = 0, int d = 0)
        {
            return a - b - c - d;
        }

    }
}