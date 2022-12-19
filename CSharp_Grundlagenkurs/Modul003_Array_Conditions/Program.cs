using System.Text;

internal class Program
{

    static void Main(string[] args)
    {
        //ARRAYS
        ///Arrays sind Collections, welche mehrere Variablen eines Datentyps speichern können. Die Größe des Arrays muss bei der
        ///Initialisierung entweder durch eine Zahl oder durch eine bestimmte Anzahl von spezifischen Elementen definiert werden.
        int[] zahlen = { 2, 4, 78, -123, -8, 0, 11111 }; //shortcut

        int[] zahlen1 = new int[] { 2, 4, 3, 34, 54 }; 

        //Der Zugiff auf einzelne Array-Positionen erfolgt durch einen Nullbasierten Index
        Console.WriteLine(zahlen[2]); //78
        zahlen[2] = 1234;
        Console.WriteLine(zahlen[2]); //1234

        //Array-Deklaration ohne direkte Initialisierung der Positionen (Größe muss angegeben werden)
        string[] worte = new string[5];


        //Achtung das sind keine Array-Methoden
        //Viele der Array-Methoden werden via -> using System.Linq angeboten 
        //u.a Count(), First(), FirstOrDefault(), Min(), Max(), Sum(), Average(), Contains(), 


        //Woichtig ist, wenn Linq-Erweiterungsmethoden angeboten werden, dann: 
        //zahlen.Length ist schneller als zahlen.Count()


        Console.WriteLine(zahlen.Length);//Hier bekommt man sofort die Array-Größe ausgegeben
        Console.WriteLine(zahlen.Count());//Hier wird ermittelt 



        #region Zweidimensionales Array

        //Mehrdimensionales Array
        int[,] zweiDimArray = new int[3, 5];
        zweiDimArray[0, 0] = 1;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                zweiDimArray[i, j] = i * j;
            }
        }
        Console.WriteLine(zweiDimArray[2, 3]);
        #endregion


        #region If-Statement


        //Deklaration und Initialisierung von Beispiel-Variablen
        int a = 23;
        int b = 23;

        //IF-ELSEIF-ELSE-Block
        ///Das Programm wird den ersten Block ausführen, bei welchem er auf eine wahre Bedingung trifft und dann am Ende des Blocks mit
        ///dem Code weiter machen
        if (a < b)
        {
            Console.WriteLine("A ist kleiner als B");
        }
        //Es kann beliebig viele ELSE-IF-Blöcke geben
        else if (a > b)
        {
            Console.WriteLine("A ist größer als B");
        }
        //Wenn keine der Bedingungen wahr ist, wird der (optionale) ELSE-Block ausgeführt
        else
            Console.WriteLine("A ist gleich B");
        #endregion


        #region Kurz-Notation

        //Syntax: Bedinung ? TrueAusgabe : FalseAusgabe
        string ergebnis = (a == b) ? "A ist gleich B" : "A ist ungleich B";
        #endregion


        #region String im Vergleich

        //Bsp eines String-Vergleichs
        string name1 = "Hans";
        string name2 = "Hans";


        //Equals = gleich 
        if (name1.Equals(name2))
        {
            Console.WriteLine("Gleich");
        }

        if (name1 == name2)
            Console.WriteLine("gleich");

        #endregion  


        DateTime.IsLeapYear(2000);

    }
}