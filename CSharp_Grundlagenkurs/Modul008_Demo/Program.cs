namespace Modul008_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mensch mensch = new Mensch("Otto", "Walkes", "Mensch", 70, "Hering", new DateTime(1968, 3,3), 170, 60);


            #region virtual / override mit ToString()
            Console.WriteLine(mensch.ToString()); //Im Grunde wird hier ohne override die Methode object.ToString() aufgerufen
            #endregion
        }
    }




    public class Lebewesen
    {
        #region statische Methoden/Variablen
        public static int AnzahlLebewesen { get; private set; } = 0; //Default-Wert 0 (geht auch bei anderen Properties ;-) )

        public static string ZeigeAnzahlLebewese()
        {
            return $"Es gibt {AnzahlLebewesen} Lebewesen";
        }
        #endregion

        #region Felder und Eigentschaten -> Kapslung von Feldern 
        //Felder

        //FELDER (Membervariablen) sind die Variablen einzelner Objekte, welche die Zustände dieser Objekte definieren
        private string bezeichnung;
        private double gewicht;

        //Properties (Eigentschaften)


        //EIGENSCHAFTEN (Properties) definieren mittels Getter/Setter den Lese-/Schreibzugriff für jeweils ein Feld.
        ///In den Eigenschaften können bestimmte Bedingungen für das Lesen und Schreiben der Felder gesetzt werden, sowie der Zugriff
        ///für Lesen und Schreiben einzeln angepasst werden
        //Snippet: propfull + tab
        public string Bezeichnung
        {
            set
            {
                bezeichnung = value;
            }

            get
            {
                return bezeichnung;
            }
        }


        public double Gewicht
        {
            //set;get;
            set
            {
                if (value > 0)
                    gewicht = value;
                else
                    Console.WriteLine("Lebewesen haben kein negatives Gewicht");
            }

            get
            {
                return gewicht;
            }
        }

        //Wird in einer Eigenschaft keine Spezifizierung angegeben, generiert das Programm das entsprechende Feld unsichtbar im Hintergrund
        //Snippet: prop
        public string Lieblingsnahrung { get; set; }

        public DateTime Geburtsdatum { get; set; }

        public double Height { get; set; }
        public double Width { get; set; }

        public int Alter
        {
            get { return ((DateTime.Now - this.Geburtsdatum).Days / 365); }
        }


        #endregion



        #region Konstruktoren
        //Wenn eine Klasse keinen Konstrukor implementiert hat, baut der Kompiler einen Default-Konstruktor dazu

        //Default Konstruktor
        public Lebewesen()
        {
            AnzahlLebewesen++;
        }

        //Werte-Konstruktor (Version1)
        public Lebewesen(string bezeichnung, double gewicht, string lieblingsnahrung, DateTime geburtsdatum)
            : this()
        {
            Bezeichnung = bezeichnung;
            Gewicht = gewicht;
            Lieblingsnahrung = lieblingsnahrung;
            Geburtsdatum = geburtsdatum;
        }

        //Werte-Konstruktor (Version2) -> Verketten die Konstrutkoren 
        public Lebewesen(string bezeichnung, double gewicht, string lieblingsnahrung, DateTime geburtsdatum, double heigh, double width)
            : this(bezeichnung, gewicht, lieblingsnahrung, geburtsdatum)
        {
            this.Height = heigh;
            this.Width = width;
        }

        //Kopierkonstruktor -> Für Version 
        public Lebewesen(Lebewesen lebewesen)
            : this()
        {
            this.Gewicht = lebewesen.Gewicht;
            this.Width = lebewesen.Width;
            this.Height = lebewesen.Height;
            this.Bezeichnung = lebewesen.Bezeichnung;
            this.Geburtsdatum = lebewesen.Geburtsdatum;
            this.Lieblingsnahrung = lebewesen.Lieblingsnahrung;
        }

        ~Lebewesen()
        {
            AnzahlLebewesen--;
            Console.WriteLine($"Dekonstruktor wird aufgerufen und {Bezeichnung} wird abgebaut");
        }




        #endregion

        #region Methoden
        public void Atmen()
        {
            Console.WriteLine("Lebewesen Atmet");
        }

        public void Kommunizieren()
        {
            Console.WriteLine("Eine unscheinbare Kommunikation");
        }

        public Lebewesen GebähreKind()
        {
            return new Lebewesen(this.Bezeichnung, 0.5, "Kleine Hühner", DateTime.Now, 0.5, 0.5);
        }
        #endregion


        #region virtual/override

        public override string ToString()
        {
            string wirkönntenKompinieren =  base.ToString(); //object.ToString() wird aufgerufen

            wirkönntenKompinieren += " es lebt";

            return wirkönntenKompinieren;
        }

        #endregion
    }

    //Von Sealed kann man nicht mehr erben 
    public sealed class Mensch : Lebewesen
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        //ctor + tab +tab -> Konstruktor
        public Mensch(string vorname, string nachname, string bezeichnung, double gewicht, string lieblingsnahrung, DateTime geburtsdatum, double heigh, double width)
            :base(bezeichnung, gewicht, lieblingsnahrung, geburtsdatum, heigh, width)
        {
            this.Vorname = vorname;
            this.Nachname = nachname;
        }

        public override string ToString()
        {
            return $"Ich bin {Vorname} {Nachname} uns esse {Lieblingsnahrung}";
        }
    }

    // ERROR: 'MarsMensch': cannot derive from sealed type 'Mensch'
    //public class MarsMensch : Mensch
    //{

    //}

}