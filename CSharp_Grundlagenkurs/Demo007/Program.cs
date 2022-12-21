namespace Demo007
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Methoden/Properties (Substring, StartWith, ...) VS. Statische Methoden/Properties 

            //Klassen-Methoden stellen die Funktionalität eines Objektes sicher
            string str = "Hallo Welt";

            if (str.StartsWith("Hallo"))
            {
                string subString = str.Substring(0, 5);
            }


            //Statische Properties / Methoden stellen eine Hilfestellung für den Datentyp bereit
            string leereString = string.Empty;

            if (string.IsNullOrEmpty(leereString))
            {
                Console.WriteLine("String ist leer");
            }
            #endregion


            #region Statische Methdoden
            //Lebewesen1 (Default)
            Lebewesen lebewesen = new Lebewesen();
            //lebewesen.????
            //Statische Methoden werden nicht via Instanz angeboten. Sondern hängen am Datentyp

            int anzahl = Lebewesen.AnzahlLebewesen;
            Lebewesen.ZeigeAnzahlLebewese();


            #endregion


            #region Statische Methoden -> Sample 2

            Lebewesen lebewesen1 = new("Cat", 5.0, "Lassagne", new DateTime(1999, 2, 4), 1.2, 1.2);
            Lebewesen lebewesen2 = new("Cat", 5.0, "Lassagne", new DateTime(1999, 2, 4), 1.2, 1.2);
            Lebewesen lebewesen3 = new("Cat", 5.0, "Lassagne", new DateTime(1999, 2, 4), 1.2, 1.2);
            #endregion



            #region Dekonstruktor + GC
            lebewesen3 = null;



            //EineMethode();

            Lebewesen lebwesen4 = EineMethode();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Console.WriteLine(Lebewesen.ZeigeAnzahlLebewese());
            #endregion


            #region Dekonstrukor würde auch in Main aufgerufen werden. Wenige UseCase sind dafür geeignet

            Lebewesen lebwesenABC;

            for (int i = 0; i < 10; i++)
            {
                lebwesenABC = new("Cat", 5.0, "Lassagne", new DateTime(1999, 2, 4), 1.2, 1.2);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            #endregion

            #region Reference Types vs. Value-Types

            PersonC classP = new PersonC(30, "Anna");



            PersonS structP = new PersonS(30, "Hugo");


            //Hier werden alle Properties / Fields einzelnd kopiert
            //weiterführende Themen -> DeepCopy / Shallow Copy



            //Übergabe des Klassenobjekts (Referenztyp):
            ///Da bei der Übergabe die Referenz des Objektes an die Methode übergeben wird, wird innerhalb der Methode
            ///das Alter des Objekts manipuliert. Im Ergebnis ist das Objekt nach der Methode ein Jahr älter geworden.
            Altern(classP);

            //Übergabe des Structobjekts (Wertetyp):
            ///Als Wertetyp wird das Objekt bei der Übergabe an die Methode kopiert. Die Methode manipuliert nur die Kopie.
            ///In dem Originalobjekt sind keine Veränderungen zu beobachten. Dieses Verhalten findet scih bei allen Wertetypen.
            Altern(structP); //Struct als Wertetyp


            //Übergabe eines Wertetypen mittels ref
            ///Ducrh ref wird auch bei Wertetypen die Referenz übergeben, wodurch hier eine Manipulation des Originalobjekts durchgeführt wird.
            Altern(ref structP); //Struct als Referenz

            //Ausgabe der Alter
            Console.WriteLine($"{classP.Name}: {classP.Alter}");
            Console.WriteLine($"{structP.Name}: {structP.Alter}");

            #endregion



        } //Ende Main-Methode -> Alle lokalen Instanzen werden abgebaut


        public static Lebewesen EineMethode()
        {
            //lokale Instanzen gelten nur innerhalb von EineMethode() 
            Lebewesen lebewesen1 = new("Dog1", 5.0, "Lassagne", new DateTime(1999, 2, 4), 1.2, 1.2);
            Lebewesen lebewesen2 = new("Dog12", 5.0, "Lassagne", new DateTime(1999, 2, 4), 1.2, 1.2);
            Lebewesen lebewesen3 = new("Dog123", 5.0, "Lassagne", new DateTime(1999, 2, 4), 1.2, 1.2);

            return lebewesen3; //Übergebe eine Reference 

        } //Instanzen werden hier nicht mehr im Programm verwendet

        //Methoden, welche jeweils die Alter-Property manipulieren
        public static void Altern(PersonC person)
        {
            person.Alter++;
        }

        public static void Altern(PersonS person) //Neuer Speicheradresse und lokale Kopie wird hochgezählt
        {
            person.Alter++;
        }

        public static void Altern(ref PersonS person) //Struct wird als Reference übergeben
        {
            person.Alter++;
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
    }

    #region Referenztyp vs. Wertetyp


    //Klasse, deren Objekte als REFERENZTYPEN betrachtet werden
    class PersonC
    {
        public int Alter { get; set; }
        public string Name { get; set; }

        public PersonC(int a, string n)
        {
            Alter = a;
            Name = n;
        }
    }

    //Struct, dessen Objekte, wie sämtliche Basisdatentypen, als WERTETYPEN betrachtet werden
    struct PersonS
    {
        public int Alter { get; set; }
        public string Name { get; set; }

        public PersonS(int a, string n)
        {
            Alter = a;
            Name = n;
        }
    }
    #endregion

}