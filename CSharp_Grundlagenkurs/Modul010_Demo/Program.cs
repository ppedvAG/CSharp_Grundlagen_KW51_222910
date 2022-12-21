namespace Modul010_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person fritzchen = new Person() { Name = "Fritzchen", Age = 17 };


            List<Jahresmarktstand> toDoListeVonFritzchen = new List<Jahresmarktstand>();
            toDoListeVonFritzchen.Add(new AutoScooter(3, "Autoscooter aus Bruchsal", 300, 12));
            toDoListeVonFritzchen.Add(new HoechsteAchterbahnDerWelt(5, "Achterbahn GmbH", 1000, 100, 2000));
            toDoListeVonFritzchen.Add(new HorrotCabinett(4, "Cabinet der Kuscheltiere", 50, 7));
            toDoListeVonFritzchen.Add(new Streichelzoo(3, "Streichelzoo GmbH", 60, 6, 5));


            foreach (Jahresmarktstand aktuellerStand in toDoListeVonFritzchen)
            {
                if (aktuellerStand is IFSK18Check standMitFSK18)
                {
                    if (standMitFSK18.CheckAge(fritzchen))
                    {
                        Console.WriteLine($"{fritzchen.Name} darf  {aktuellerStand.Bezeichnung}  faheren");
                    }
                    else
                        Console.WriteLine($"{fritzchen.Name} mit seinen {fritzchen.Age}  ist zu jung ");
                }
                else
                    Console.WriteLine($"{fritzchen.Name} darf {aktuellerStand.Bezeichnung} faheren");

            }


            #region IList<T> 
            IList<Jahresmarktstand> toDoListeVonFritzchen2 = new List<Jahresmarktstand>();
            toDoListeVonFritzchen2.Add(new AutoScooter(3, "Autoscooter aus Bruchsal", 300, 12));
            toDoListeVonFritzchen2.Add(new HoechsteAchterbahnDerWelt(5, "Achterbahn GmbH", 1000, 100, 2000));
            toDoListeVonFritzchen2.Add(new HorrotCabinett(4, "Cabinet der Kuscheltiere", 50, 7));
            toDoListeVonFritzchen2.Add(new Streichelzoo(3, "Streichelzoo GmbH", 60, 6, 5));
            #endregion

        }
    }


    public interface IFSK18Check
    {
        bool CheckAge(Person alter);
    }

    public class Jahresmarktstand
    {
        public int Mitarbeiteranzahl { get; set; }  
        public string Bezeichnung { get; set; } 

        public double FlaecheInQuatratmeter { get; set; }

        public Jahresmarktstand(int mitarbeiteranzahl, string bezeichnung, double flaecheInQuatratmeter)
        {
            Mitarbeiteranzahl = mitarbeiteranzahl;
            Bezeichnung = bezeichnung;
            FlaecheInQuatratmeter = flaecheInQuatratmeter;
        }
    }


    public class AutoScooter : Jahresmarktstand
    {
        public AutoScooter(int mitarbeiteranzahl, string bezeichnung, double flaecheInQuatratmeter, int anzahlAutos)
            :base(mitarbeiteranzahl, bezeichnung, flaecheInQuatratmeter)
        {
            AnzahlDerAutos = anzahlAutos;
        }
        public int AnzahlDerAutos { get; set; }
    }

    public class HoechsteAchterbahnDerWelt : Jahresmarktstand, IFSK18Check
    {
        public HoechsteAchterbahnDerWelt(int mitarbeiteranzahl, string bezeichnung, double flaecheInQuatratmeter, int hoehe, int streckenInMeter)
             : base(mitarbeiteranzahl, bezeichnung, flaecheInQuatratmeter)
        {
            Hoehe = hoehe;
            StreckenInMeter = streckenInMeter;
        }

        public int Hoehe { get; set; }
        public int StreckenInMeter { get; set; }

        public bool CheckAge(Person alter)
        {
            return alter.Age >= 18 ? true : false;  
        }
    }

    public class Streichelzoo : Jahresmarktstand
    {
        public Streichelzoo(int mitarbeiteranzahl, string bezeichnung, double flaecheInQuatratmeter, int anzahlTiere, int anzahl)
             : base(mitarbeiteranzahl, bezeichnung, flaecheInQuatratmeter)
        {
            AnzahlTiere = anzahlTiere;
            Anzahl = anzahl;
        }

        public int AnzahlTiere { get; set; }
        public int Anzahl { get; set; } = 5;
    }

    public class HorrotCabinett : Jahresmarktstand, IFSK18Check
    {
        public HorrotCabinett(int mitarbeiteranzahl, string bezeichnung, double flaecheInQuatratmeter, int schockerAnzahl)
             : base(mitarbeiteranzahl, bezeichnung, flaecheInQuatratmeter)
        {
            SchockerAnzahl = schockerAnzahl;
        }

        public int SchockerAnzahl { get; set; }

        public bool CheckAge(Person alter)
        {
            return alter.Age >= 18 ? true : false;
        }
    }


    public class Person
    {
        public string Name
        {
            get;
            set;
        }

        public int Age { get; set; }
    }





}