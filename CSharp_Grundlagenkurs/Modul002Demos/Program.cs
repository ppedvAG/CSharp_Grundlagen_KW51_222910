
//Mittels der USING-Anweisung kann ein vereinfachter Zugriff auf Program-Externe Klassen ermöglicht werden. 
//using System -> .NET 5.0 entfält hier -> global usings Feature in .NET 6/7;


//NAMESPACE: Die Umgebung unseres aktuellen Programm: Innerhalb der geschweiften Klammern befinden sich alle Datentypen (Klassen, Struct, Events, Enums..usw)
//in dem Namespace -> Modul002Demos. 


using System.Text;


namespace Modul002Demos
{
    //Main - Methode ist dewr Einstieg jedes C# Programm 
    //Eine Alternative zu Main-Methode ist das Top-Level Statement -> 
    //Bei Aufruf der Exe-Datei, wird nach Program.Main gesucht. daher muss die Main-Methode statisch sein
    internal class Program
    {
        /// <summary>
        /// Main Methode ist der Einstieg für dieses Programm 
        /// </summary>
        /// <param name="args">Hier können wir für Programm-Parameter übergeben </param>
        static void Main(string[] args)
        {
            #region Was ist ein Region -> hier kann ich SourceCode einklappbar darstellen 
            #endregion

            #region Deklaration / Initialisierung von Variablen 
            //Deklaration einer Integer-Vaiable -> Variable wird im Arbeitsspeicher reserviert
            int alter; //Wenn wir keinen Werz zuweisen ist der Defaut-Wert '0'

            //Initialisierung der Integer-Variable
            alter = 32;

            //Gleichzeitige Deklaration und Initialisierung einer String-Variablen
            string city = "Berlin";
            //Cw + tab + tab -> Console.WriteLine
            Console.WriteLine(city);

            //Deklaration und Initialisierung einer Integer-Variablen mithilfe einer anderen Integer-Variablen
            int doppeltesAlter = alter * 2;
            Console.WriteLine(doppeltesAlter);
            Console.WriteLine(doppeltesAlter + alter); //Int-Berechnung innerhalb von String-Ausgabe
            #endregion

            #region Ganzzahlige-Datentypen
            //short -> Int16 -> 16 bit 
            short hoechsteShortZahl = short.MaxValue;
            short niedrigsteShortZahl = short.MinValue;
            ushort usingedShort = ushort.MinValue; //0

            //int -> Int32 -> 32 bit
            int hoechsteIntegerZahl = int.MaxValue;
            int minIntegerZahl = int.MinValue;
            //unsigned Datentypen von 0 -> [MaxValue]
            uint minUIntZahl = uint.MinValue;
            uint maxUIntZahl = uint.MaxValue;

            //64bit -> Int64 -> 64 bit
            long großteGanzzahligeZahl = long.MaxValue; 
            ulong usignedLong = long.MaxValue;

            // C# ->    int -> (Kompilierung) -> Int32
            // VB.NET ->Integer -> Int32 
            #endregion

            #region Fließkomme - Datentypen
            //Eine Gleitkommazahl | ±1.5 × 10−45 zu ±3.4 × 1038	~6–9 Stellen	4 Bytes   | System.Single 
            float eineWeitereKommazahl = 3.14f;  //

            double eineKommazahl = 3.14; //Eine Gleitkommazahl | ±5,0 × 10−324 bis ±1,7 × 10308	~15–17 Stellen	8 Bytes | System.Double
                                         //const double -> Math.PI

            decimal moneyValue = 1500m; // Suffix ist m -> Decimal wird für Geldbeträge verwendet und hat nach dem Komma, die höchste Genauigkeit
                                        // ±1.0 × 10-28 to ±7.9228 × 1028	28-29 Stellen	16 Bytes	System.Decimal
            #endregion

            #region Zeichen-Datentypen

            char ichBinEinZeichen = 'A'; //Einmal erhalten den Buchstaben 

            Console.WriteLine(ichBinEinZeichen); //Ausgabe eines Buchstabens 
            Console.WriteLine((int)ichBinEinZeichen); //Ascii-Wert -> 65 


            string eineZeichenkette = "Hallo Welt";
            char ersterBuchstabe = eineZeichenkette[0];
            #endregion

            #region Was ist Bool?
            bool boolVariable; //Default-Wert ist false 

            bool istWahr = true;
            bool isFalsch = false;
            #endregion

            #region Nullbare Datentypen

            //Nullbare Datentypen
            bool? nullableBool = null;
            int? nullableInt = null;

            //nullableInt.HasValue; (true/false) 
            //wenn befüllt == true
            //dann nullableInt.Value (zugriff auf Variableninhalt) 

            //Nullable Datentypen werden beim defensiven Programmieren verwendet. 
            if (nullableBool.HasValue)
                Console.WriteLine(nullableBool.Value);



            //normalerString = ""; 
            string normalString = string.Empty;
            string? nullableString = null; 

            //Prüfe auf Null oder ""
            if (string.IsNullOrEmpty(nullableString))
            {
                //string wäre leer 
            }

            #endregion



            #region Unterschied zwischen Wertetypen und Referenztypen

            //Wertetypen sind: short, int, long, bool, uint.. (alle Zahlen-Datentypen), struct, enum, double, float, decimal
            //Wertetypen geben eine Kopie weiter.

            //Variable X und Variable Z
            int x = 509; //X & Y hat ein eigenen Speicheradresse

            

            int y = x; //Hier wird eine Kopie weitergeben 
            x = 501;
            Console.WriteLine($"{y} hat den Wert 509 immer noch");

            //Referenztypen: class, interface, string, delegate 

            //Integer als Referenztyp

            #endregion

            #region String-Ausgabe
            alter = 33;
            city = "Hamburg";

            //Verwenden einer Variable
            string satz = "Ich bin " + alter + " Jahre alt und wohne in " + city;
            
            //Variable wird ausgegeben 
            Console.WriteLine(satz);

            //Zusammbau des Strings + Ausgabe 
            Console.WriteLine("Ich bin " + alter + " Jahre alt und wohne in " + city);

            //Alte Ausgabevariante nach printf - Stil
            Console.WriteLine("Ich bin {0} Jahre alt und wohne in {1} ", alter, city);

            //$-Operator (Variablen werden direkt mit {}-Klammern geschrieben
            Console.WriteLine($"Ich bin {alter} Jahre alt und wohne in {city}");

            int a = 45;
            int b = 12;

            Console.WriteLine($"{a} + {b} = {a+b}");


            #region Performance-Tip -> StringBuilder
            //Kein Einstiegsthemen -> Bei string mit dem '+' Operator innerhalb einer Schleife, ist der StringBuilder performanter
            StringBuilder builder = new StringBuilder();
            builder.Append("Ich bin ");
            builder.Append(alter);
            builder.Append("Jahre alt");
            Console.WriteLine(builder.ToString());
            #endregion



            #region String-Formatierungen mit Escape-Sequenzen

            //Escape Sequence Represents
            //  \a Bell(alert)
            //  \b Backspace
            //  \f Form feed
            //  \n New line
            //  \r Carriage return
            //  \t Horizontal tab
            //  \v Vertical tab
            //  \'	Single quotation mark
            //  \"	Double quotation mark
            //  \\	Backslash
            //  \?	Literal question mark
            //  \ ooo ASCII character in octal notation
            //  \x hh   ASCII character in hexadecimal notation


            string bsp = "Dies ist ein \t Tabulator und dies ein \n Zeilenumbruch";

            //Problem bei Pfadausgaben mit Escape-Sequenzen

            string windowsPath = "C:\\Windows\\Temp";


            //Mit verbatimString schalten wir die Escape-Zeichen aus 
            string verbatimString = @"c:\Windows\Temp"; //intern wird aber mit doppelten Backslash gearbeitet -> c:\\Windows\\Temp

            string combi = @$"C:\{city}";
            #endregion


            #region Eingabe eines Strings mit ReadLine
            Console.Write("Bitte gib deinen Namen ein: "); //Rest der Zeile wird für die Eingabe verwendet
            string eingabe = Console.ReadLine();
            Console.WriteLine($"Dein Name ist also {eingabe}.");
            #endregion

            #region Eingabe einer Zahl 
            Console.Write("Bitte gebe eine Zahl ein: ");
            string zahlAlsString = Console.ReadLine();

            //Umwandeln 
            int zahl = int.Parse(zahlAlsString);
            zahl = zahl * 2;


            Console.WriteLine(zahl); //Impliziet in ein String umgewandelt
            #endregion

            #region ReadKey
            Console.Write("Gebe ein Zeichen (Zahl, Komma, Buchstaben etc)");
            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.A)
            {
                //Taste A wurde gedrückt 
            }
            #endregion




            #endregion

            #region implizietes/explizietes konventieren

            #region int.Parse
            zahl = int.Parse(zahlAlsString);
            zahl = zahl * 2;


            Console.WriteLine(zahl); //Impliziet in ein String umgewandelt
            #endregion

            #region Convert.To...

            zahl = Convert.ToInt32(zahlAlsString);
            #endregion


            #region int.TryParse
            int convertedZahl;
            //ref = Referenz | out ist auch Referenz, muss allerdings befüllt werden 
            if (int.TryParse(zahlAlsString, out convertedZahl))
            {
                //Hier wissen wir, zahlAlsString ist 100% eine Zahl
                //Oder convertedZahl beinhaltet einen nummerischen Wert 

                Console.WriteLine(convertedZahl); 
            }
            #endregion

            int zahl1 = 123;
            double doubleZahl = zahl1; //Kommastellen kann man immer hinzufügen

            double doubleZahl1 = 123.5;
            zahl1 = (int)doubleZahl; //Wird abgeschnitten


            int outputZahl = Convert.ToInt32(doubleZahl1);
            //Abgeschnitten 
            Console.WriteLine("Convert.ToInt32: " + outputZahl); //124

            //int.Parse geht nur mit Strings 
            //outputZahl = int.Parse(doubleZahl);
            //Console.WriteLine("int.Parse: " + outputZahl);

            //Runden mit Floor
            Console.WriteLine("Math.Floor: " + Math.Floor(doubleZahl1));

            //Round + ab Kommastelle
            Console.WriteLine("Math.Round: " + Math.Round(doubleZahl1));
            Console.WriteLine("Math.Round with Digits-Angabe: " + Math.Round(doubleZahl1, 2));
            #endregion


            #region Teilen durch 0


            //Bsp für Teilung durch 0 von Gleitkommazahlen
            double zero = 0.0;
            double z = 2 / zero;
            Console.WriteLine(z);

            #endregion


            #region Mathematische Operationen
            int zahlOfYear2022 = 100;

            Console.WriteLine(zahlOfYear2022++); //100 wird ausgegeben -> Danach wird erhöht (101)

            zahlOfYear2022 = 100;
            Console.WriteLine(++zahlOfYear2022); //zuerst wird erhöht -> dann wird ausgegeben 

            #endregion
        }
    }

   
}




