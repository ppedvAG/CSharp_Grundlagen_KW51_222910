namespace Modul004Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Schleifen

            int a = 0;
            int b = 10;

            //WHILE-Schleife
            ///Die WHILE-Schleife wird wiederholt, solange die Bedingung wahr ist. Ist die Bedingung von vornherein unwahr, dann wird die Schleife
            ///übersprungen
            while (a < b)
            {
                Console.WriteLine("A ist kleiner B");
                a++;

                //Vorab können wir eine Schleife abbrechen

                if (a == 5)
                    break; 

            }
            Console.WriteLine("Schleifenende");


            a = 0;

            do
            {
                
                a++;

                if (a % 2 != 0)
                    continue;

                Console.WriteLine(a);

               
            } while (a < 10);








            //FOR-Schleife
            ///Der FOR-Schleife wird ein Laufindex (i) sowie eine Bedingung und eine Anweisung übergeben. Am Ende jedes Durchlaufes wird die
            ///Anweisung ausgeführt. Wenn die Bedingung nicht (mehr) wahr ist, wird kein (weiterer) Schleifendurchlauf begonnen.
            for (int i = 0; i < 10; i += 2)
            {
                Console.WriteLine(i);

                i++;
            }




            int[] zahlen = { 2, 3, 5, 4 };
            //Iteration über ein Array mittels For-Schleife
            for (int i = 0; i < zahlen.Length; i++)
            {
                Console.WriteLine(zahlen[i]);
            }

            //FOREACH-Schleifen können über Collections laufen und sprechen dabei jedes Element genau einmal an
            foreach (int item in zahlen)
            {
                Console.WriteLine(item);
            }




            #endregion

            #region Endlosschleife
            //while (true) //Endlosschleife
            //{

            //    //Darstellung eines Hauptmenüs 
            //    ConsoleKeyInfo key =  Console.ReadKey();

                
            //    if (key.Key == ConsoleKey.Q)
            //        break;
            //}

            ////Würde gehen...aber man nimmt eine for-Schleife
            //for (;true;)
            //{
            //    ConsoleKeyInfo key = Console.ReadKey();


            //    if (key.Key == ConsoleKey.Q)
            //        break;
            //}
            #endregion


            #region Enums
            //ENUMERATOREN sind spezialisierte selbst-definierte Datentypen mit festgelegten möglichen Zuständen.
            ///Dabei ist jeder Zustand an einen Integer-Wert gekoppelt, wodurch eine explizite Umwandlung (Cast) möglich ist. (vgl. Datentyp-Definition unten)

            #region Anti-Beispiel -> Der Blues der C/C++ Entwickler
            //So bitte nicht!!!!!
            string[] wochentageStringArray = { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" };

            //So bitte nicht!!!!!
            if (wochentageStringArray[3] == "Mi")
            {
                
            }
            #endregion

            #region Ausgabe eines Enums
            Wochentag wochentag = Wochentag.Di;
            Console.WriteLine($"Heute is also {wochentag}"); //Di
            #endregion


            #region Enum und sein Index

            //For-Schleife über die möglichen Zustande des Enumerators
            Console.WriteLine("Welcher Wochentag ist dein Lieblingstag?");
            for (int i = 1; i < 8; i++)
            {
                Console.WriteLine($"{i}: {(Wochentag)i}");
            }
            #endregion

            //Speichern einer Benutzereingabe (Int) als Enumerator
            //Cast: Int -> Wochentag

            wochentag = (Wochentag)int.Parse(Console.ReadLine());
            Console.WriteLine($"Dein Lieblingstag ist alsoi {wochentag}");

            #endregion
        }
    }


    enum Wochentag { Mo=1, Di, Mi, Do, Fr, Sa, So}
}