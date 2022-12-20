namespace Modul006_Demo_Klassen_Eigenschaften_Felder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Anti-Beispiel
            CPlusPlusLebewesen cPlusPlusLebewesen = new CPlusPlusLebewesen();

            //Ist unschön -> Deswegen wird auch kein Set/Get-Methoden verwenden. Ein wenig mehr Kontrast ist gewünscht
            cPlusPlusLebewesen.SetBezeichnung("Dog");
            cPlusPlusLebewesen.Atmen();
            #endregion


            #region Beispiel Properties / Felder
            Lebewesen lebewesen = new Lebewesen(); //Defaultkonstruktor wird aufgerufen, den es eigentlich noch nicht geben darf? Warum->

            lebewesen.Bezeichnung = "Fisch";
            lebewesen.Lieblingsnahrung = "Wasserflöhe";
            lebewesen.Geburtsdatum = new DateTime(2020, 5, 5);
            lebewesen.Gewicht = 1.5;
            int alter = lebewesen.Alter;
            #endregion

            #region Konstruktoren

            Lebewesen dog = new Lebewesen("Dog", 5.5, "Huhn", DateTime.Now);

            #endregion





        }
    }
    #region Anit-Beispiel
    //Klasse ist eine Vorlage für ein Object.
    //Sie bestimmt die Eigentschaften und Funktionen.
    public class CPlusPlusLebewesen
    {
        private string bezeichnung;

        //Methoden die keien Funktionalität aufweisen-> eher Felder Kapseln
        public void SetBezeichnung(string bez) 
        {
            bezeichnung = bez;
        }

        public string GetBezeichnung()
            => bezeichnung;

        /// <summary>
        /// Methode die eine Funktionalität anbietet
        /// </summary>
        public void Atmen()
        {
            Console.WriteLine("Lebewesen Atmet");
        }
    }
    #endregion

    public class Lebewesen
    {
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
                else Console.WriteLine("Lebewesen haben kein negatives Gewicht");
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
            :this (bezeichnung, gewicht, lieblingsnahrung, geburtsdatum)
        {
            this.Height = heigh;
            this.Width = width;
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
    }


}