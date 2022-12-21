namespace Modul008_LabSolution
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Fahrzeug
    {
        #region Lab 06: Properties, Methoden, Konstruktor

        //Properties
        public string Name { get; set; }
        public int MaxGeschwindigkeit { get; set; }
        public int AktGeschwindigkeit { get; set; }
        public double Preis { get; set; }
        public bool MotorLäuft { get; set; }

        //Konstruktor mit Übergabeparametern und Standartwerten
        public Fahrzeug(string name, int maxG, double preis)
        {
            this.Name = name;
            this.MaxGeschwindigkeit = maxG;
            this.Preis = preis;
            this.AktGeschwindigkeit = 0;
            this.MotorLäuft = false;
        }

        //Methode zur Ausgabe von Objektinformationen
        public virtual string Info()
        {
            if (this.MotorLäuft)
                return $"{this.Name} kostet {this.Preis}€ und fährt momentan mit {this.AktGeschwindigkeit} von maximal {this.MaxGeschwindigkeit}km/h.";
            else
                return $"{this.Name} kostet {this.Preis}€ und könnte maximal {this.MaxGeschwindigkeit}km/h fahren.";
        }

        //Methode zum Starten des Motors
        public void StarteMotor()
        {
            if (this.MotorLäuft)
                Console.WriteLine($"Der Motor von {this.Name} läuft bereits.");
            else
            {
                this.MotorLäuft = true;
                Console.WriteLine($"Der Motor von {this.Name} wurde gestartet.");
            }
        }

        //Methode zum Stoppen des Motors
        public void StoppeMotor()
        {
            if (!this.MotorLäuft)
                Console.WriteLine($"Der Motor von {this.Name} ist bereits gestoppt");
            else if (this.AktGeschwindigkeit > 0)
                Console.WriteLine($"Der Motor kann nicht gestoppt werden, da sich {this.Name} noch bewegt");
            else
            {
                this.MotorLäuft = false;
                Console.WriteLine($"Der Motor von {this.Name} wurde gestoppt.");
            }
        }

        //Methode zum Beschleunigen und Bremsen
        public void Beschleunige(int a)
        {
            if (this.MotorLäuft)
            {
                if (this.AktGeschwindigkeit + a > this.MaxGeschwindigkeit)
                    this.AktGeschwindigkeit = this.MaxGeschwindigkeit;
                else if (this.AktGeschwindigkeit + a < 0)
                    this.AktGeschwindigkeit = 0;
                else
                    this.AktGeschwindigkeit += a;

                Console.WriteLine($"{this.Name} bewegt sich jetzt mit {this.AktGeschwindigkeit}km/h");
            }
        }

        #endregion


        #region Lab 07: Statische Member, Destruktor

        public static int AnzahlFahrzeuge { get; set; } = 0;

        public static string ZeigeAnzahlFahrzeuge()
        {
            return $"Es wurden {AnzahlFahrzeuge} Fahrzeuge gebaut.";
        }

        ~Fahrzeug()
        {
            Console.WriteLine($"{this.Name} wurde gerade verschrottet.");
        }

        #endregion
    }

    public class Schiff : Fahrzeug
    {
        //Klasseneigener Enum
        public enum SchiffsTreibstoff { Diesel = 0, Dampf, Wind, Muskelkraft }

        //Klasseneigene Property
        public SchiffsTreibstoff Treibstoff { get; set; }

        //Konstruktor mit Bezug auf den Konstruktor der Mutterklasse (base)
        public Schiff(string name, int maxG, double preis, SchiffsTreibstoff treibstoff) : base(name, maxG, preis)
        {
            this.Treibstoff = treibstoff;
        }

        //Überxchreibung der Info()-Methode mit Bezug auf die Methode der Mutterklasse (base)
        public override string Info()
        {
            return "Das Schiff " + base.Info() + $" Es fährt mit {this.Treibstoff}.";
        }
    }

    //vgl. Schiff
    public class PKW : Fahrzeug
    {
        public int AnzahlTueren { get; set; }

        public PKW(string name, int maxG, double preis, int anzTueren) : base(name, maxG, preis)
        {
            this.AnzahlTueren = anzTueren;
        }

        public override string Info()
        {
            return "Der PKW " + base.Info() + $" Er hat {this.AnzahlTueren} Türen.";
        }
    }

    //vgl. Schiff
    public class Flugzeug : Fahrzeug
    {
        public int MaxFlughöhe { get; set; }

        public Flugzeug(string name, int maxG, double preis, int maxFH) : base(name, maxG, preis)
        {
            this.MaxFlughöhe = maxFH;
        }

        public override string Info()
        {
            return "Das Flugzeug " + base.Info() + $" Es kann bis auf {this.MaxFlughöhe}m aufsteigen.";
        }
    }
}