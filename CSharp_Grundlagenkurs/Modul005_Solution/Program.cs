namespace Modul005_Solution
{
    internal class Program
    {
        //Enum-Definition
        enum Rechenoperation { Addition = 1, Subtraktion, Multiplikation, Division }

        #region Alternative 1:
        static void Main(string[] args)
        {
            //Schleife für Programm-Wiederholung
            do
            {
                double zahl1, zahl2;

                Console.WriteLine();

                //Eingabe und Parsing der ersten Zahl
                do
                    Console.Write("Gib eine Zahl ein: ");
                while (!double.TryParse(Console.ReadLine(), out zahl1));

                //Eingabe und Parsing der zweiten Zahl
                do
                    Console.Write("Gib eine weitere Zahl ein: ");
                while (!double.TryParse(Console.ReadLine(), out zahl2));

                //Anzeige der möglichen Rechenoperationen
                Console.WriteLine("\nWähle eine Rechenoperation:");
                for (int i = 1; i <= Enum.GetValues(typeof(Rechenoperation)).Length; i++)
                {
                    Console.WriteLine($"{i}: {(Rechenoperation)i}");
                }

                //Abfrage der Benutzereingabe
                int op;
                do
                    Console.Write("Auswahl: ");
                while (!int.TryParse(Console.ReadLine(), out op));
                Rechenoperation operation = (Rechenoperation)op;

                //Deklaration und Initialisierung der Ergebnisvariablen
                double ergebnis = Berechne(zahl1, zahl2, operation, out string symbol);

                if (ergebnis.Equals(double.NaN))
                    Console.WriteLine("\nFehlerhafte Eingabe der Rechenoperation");
                else if (ergebnis == double.PositiveInfinity)
                    Console.WriteLine("\nEine Teilung durch 0 ist nicht möglich");
                else
                    //Ausgabe des Ergebnisses
                    Console.WriteLine($"\nErgebnis: {zahl1} {symbol} {zahl2} = {ergebnis}");

                //Frage nach der Wiederholung des Programms
                Console.WriteLine("\nWiederholen? (Y/N) ");
                //Schleifenbedingungsprüfung anhand Tastendruck des Benutzers
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);
        }

        static double Berechne(double z1, double z2, Rechenoperation o, out string symbol)
        {
            symbol = "";

            //Switch zur Auswahl der Rechenoperation
            switch (o)
            {
                //Berechnung des Ergebnisses
                case Rechenoperation.Addition:
                    symbol = "+";
                    return z1 + z2;
                case Rechenoperation.Subtraktion:
                    symbol = "-";
                    return z1 - z2;
                case Rechenoperation.Multiplikation:
                    symbol = "*";
                    return z1 * z2;
                case Rechenoperation.Division:
                    symbol = "/";
                    return z1 / z2;
                default:
                    return double.NaN;
            }
        }
        #endregion

        #region Alternative 2:
        static void Main2(string[] args)
        {
            //Schleife für Programm-Wiederholung
            do
            {
                double zahl1, zahl2;

                Console.WriteLine();

                //Eingabe und Parsing der ersten Zahl
                do
                    Console.Write("Gib eine Zahl ein: ");
                while (!double.TryParse(Console.ReadLine(), out zahl1));

                //Eingabe und Parsing der zweiten Zahl
                do
                    Console.Write("Gib eine weitere Zahl ein: ");
                while (!double.TryParse(Console.ReadLine(), out zahl2));

                //Anzeige der möglichen Rechenoperationen
                Console.WriteLine("\nWähle eine Rechenoperation:");
                for (int i = 1; i <= Enum.GetValues(typeof(Rechenoperation)).Length; i++)
                {
                    Console.WriteLine($"{i}: {(Rechenoperation)i}");
                }

                //Abfrage der Benutzereingabe
                int op;
                do
                    Console.Write("Auswahl: ");
                while (!int.TryParse(Console.ReadLine(), out op));
                Rechenoperation operation = (Rechenoperation)op;

                //Deklaration und Initialisierung der Ergebnisvariablen
                double ergebnis = 0.0;
                string symbol = "";

                //Switch zur Auswahl der Rechenoperation
                switch (operation)
                {
                    //Berechnung des Ergebnisses
                    case Rechenoperation.Addition:
                        ergebnis = Addiere(zahl1, zahl2);
                        symbol = "+";
                        break;
                    case Rechenoperation.Subtraktion:
                        ergebnis = Subtrahiere(zahl1, zahl2);
                        symbol = "-";
                        break;
                    case Rechenoperation.Multiplikation:
                        ergebnis = Multipliziere(zahl1, zahl2);
                        symbol = "*";
                        break;
                    case Rechenoperation.Division:
                        ergebnis = Dividiere(zahl1, zahl2);
                        symbol = "/";
                        break;
                    default:
                        //Fall, welcher eintrofft, wenn keine valide Rechenoperation ausgewählt wurde
                        Console.WriteLine("\nFehlerhafte Eingabe bei Auswahl der Rechenoperation");
                        Console.WriteLine("Wiederholen? (Y/N) ");
                        continue;

                }

                if (ergebnis == double.PositiveInfinity)
                    Console.WriteLine("\nEine Teilung durch 0 ist nicht möglich");
                else
                    //Ausgabe des Ergebnisses
                    Console.WriteLine($"\nErgebnis: {zahl1} {symbol} {zahl2} = {ergebnis}");

                //Frage nach der Wiederholung des Programms
                Console.WriteLine("\nWiederholen? (Y/N) ");
                //Schleifenbedingungsprüfung anhand Tastendruck des Benutzers
            } while (Console.ReadKey(true).Key == ConsoleKey.Y);
        }

        private static double Dividiere(double zahl1, double zahl2)
        {
            return zahl1 / zahl2;
        }

        private static double Multipliziere(double zahl1, double zahl2)
        {
            return zahl1 * zahl2;
        }

        private static double Subtrahiere(double zahl1, double zahl2)
        {
            return zahl1 - zahl2;
        }

        private static double Addiere(double zahl1, double zahl2)
        {
            return zahl1 + zahl2;
        }
        #endregion
    }
}