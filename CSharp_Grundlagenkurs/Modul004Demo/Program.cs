using System.Runtime.ConstrainedExecution;
using System;

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
                Console.WriteLine("");
            }
            #endregion

            #region Ausgabe eines Enums
            Wochentag wochentag = Wochentag.Di;
            Console.WriteLine($"Heute is also {wochentag}"); //Di
            #endregion


            #region Enum und sein Index und Casting

            //For-Schleife über die möglichen Zustande des Enumerators
            Console.WriteLine("Welcher Wochentag ist dein Lieblingstag?");
            for (int i = 1; i < 8; i++)
            {
                Console.WriteLine($"{i}: {(Wochentag)i}");
            }
            #endregion

            #region Weitere Castings
            //Speichern einer Benutzereingabe (Int) als Enumerator
            //Cast: Int -> Wochentag

            wochentag = (Wochentag)int.Parse(Console.ReadLine());
            Console.WriteLine($"Dein Lieblingstag ist  {wochentag}");


            //wochentag wird zu Fr
            wochentag = (Wochentag)Enum.Parse(typeof(Wochentag), "So");
            #endregion

            #region Switch-Statement mit Typprüfung und Casting

            //Geschwindikeit hat ein Switch einen Vortel 
            if (wochentag == Wochentag.Fr)
            {
                Console.WriteLine("Ich bin dann mal offline");
            }
            else if (wochentag == Wochentag.Sa)
            {
                Console.WriteLine("Ich bin am Sa mal offline");
            }
            else if (wochentag == Wochentag.So)
            {
                Console.WriteLine("Ich bin am So offline");
            }
            else
            {
                Console.WriteLine("Wochenende schon vorbei?");
            }

            switch (wochentag)
            {
                case Wochentag.Mo:
                    //Code den wir ausführen wollen 
                    Console.WriteLine("Mo beginnt die Woche");
                    break;
                case Wochentag.Di:
                    Console.WriteLine("Es ist Di");
                    break;
                case Wochentag.Mi:
                    break;
                case Wochentag.Do:
                    break;
                case Wochentag.Fr: //Wenn Fr oder Sa oder So 
                case Wochentag.Sa:
                case Wochentag.So:
                    Console.WriteLine("Geschenke am WE einkaufen");
                    break;
                default:
                    Console.WriteLine("Kein Wochentag wurde selektiert");
                    break;
            }



            MethodeXYZ(-37);
            MethodeXYZ("Hello User");

            IfMethodeWithObject(32);

            #endregion


            #region BitFlags
            
            // Display all possible combinations of values.
            Console.WriteLine(
                 "All possible combinations of values without FlagsAttribute:");

            for (int val = 0; val <= 16; val++)
                Console.WriteLine("{0,3} - {1:G}", val, (SingleFarbton)val);





            // Display all combinations of values, and invalid values.
            Console.WriteLine(
                 "\nAll possible combinations of values with FlagsAttribute:");
            for (int val = 0; val <= 16; val++)
                Console.WriteLine("{0,3} - {1:G}", val, (MultiFarbton)val);
            #endregion

            #endregion
        }

        public static void MethodeXYZ(object param)
        {
            switch (param)
            {
                case 5:
                    Console.WriteLine("zahl ist 5");
                    break;
                case int z when z < 0:
                    Console.WriteLine("z < 0");
                    break;
                case string str when str.StartsWith("Hello"):
                    Console.WriteLine("World");
                    break;
                default:
                    Console.WriteLine("Typ nicht erkannt");
                break;
            }
        }


        public static void IfMethodeWithObject(object param)
        {
            if (param is int number)
            {
                if (number < 0)
                {
                    Console.WriteLine("z < 0");
                }
            }
        }
    }


    enum Wochentag { NotInitialized=0, Mo, Di, Mi, Do, Fr, Sa, So}

    
    //Enum Ohne Flags-Attribute
    enum SingleFarbton : short
    {
        None = 0,
        Black = 1,
        Red = 2,
        Green = 4,
        Blue = 8
    };

    [Flags]
    enum MultiFarbton : short
    {
        None = 0,
        Black = 1,
        Red = 2,
        Green = 4,
        Blue = 8
    };

}