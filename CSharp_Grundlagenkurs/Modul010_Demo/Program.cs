using Microsoft.Data.SqlClient;
using System.Diagnostics; 

namespace Modul010_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Sample 1
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
            #endregion

            #region Sample2 -> IDispose


            #region ShowCase -> Wo steckt IDisposeable drin
            
            
            
            
            //Warum ist using für uns sehr wichtig? Das using garantiert, beim Verlassen des using-Blocks, dass Dispose augerufen wird

            SqlConnection conn = new SqlConnection(/* Wir haben kein ConnectionString */);
            conn.Open(); //Würde hier ein Fehler entstehen. 

            // Fehler würde passieren

            //Muss sichergestellt werden, dass die SqlConnection auch wieder abgebaut wird 
            conn.Close();
            



            using (SqlConnection conn1 = new SqlConnection())
            {
                conn1.Open();

            } //Objekt wird abgebaut.  -> conn1.Dispose();


            FileStream fileStream = new FileStream(@"C:\Temp\Hallo.txt", FileMode.Create);


            fileStream.Dispose();
            #endregion


            #region Eigene Objekte mit dem using - Statement

            //using + IDisposeable 
            using (Person person = new Person()) 
            { 

            } //Dispose wird augerufen 
            #endregion

            #endregion

            #region Sample3 -> IEquatable

            Person person1 = new Person() { Name = "Dagobert Duckl", Age = 55 };
            Person person2 = new Person() { Name = "Dagobert Duckl", Age = 55 };

            //Bei Klassen werden die Speicheradresse verglichen 
            if (person1 == person2)
            {
                Console.WriteLine("gleich");
            }
            else
                Console.WriteLine("ungleich"); //person1 und person2 -> werden als ungleich angesehen 


            //Record verwendet intern das Interface -> IEquatable
            Car car1 = new Car("VW", "Polo", 2020);
            Car car2 = new Car("VW", "Polo", 2020);

            if (car1 == car2)
            {
                Console.WriteLine("gleich");
            }
            else
                Console.WriteLine("ungleich");
            #endregion

            #region Interface Vs. abstract classes

            /*
             *  How can you decide whether to use an abstract class or an interface in an application?
                Answer:
                If you want to have some centralized or default behaviors, an 
                abstract class is a better choice. In those cases, you can provide 
                some default implementation. On the other hand, the interface 
                implementation starts from scratch and indicates some kind of 
                rules/contracts such as what is to be done, but it does not enforce 
                the “how” part upon you. Also, interfaces are preferred when you 
                are trying to implement the concept of multiple inheritance.
                Remember that if you need to add a new method in an interface, 
                then you need to track down all the implementations of that 
                interface, and you need to put the concrete implementation for 
                that method in all those places. In such a case, an abstract class is 
                a better choice because you can add a new method in an abstract 
                class with a default implementation, and the existing code can run 
                smoothly.




                //
                Wenn Sie einige zentralisierte oder standardmäßige Verhaltensweisen haben möchten, ist eine 
                abstrakte Klasse die bessere Wahl. In diesen Fällen können Sie eine eine Standardimplementierung anbieten. 
            
                Auf der anderen Seite beginnt die Implementierung der Interface - Implementierung bei Null an und gibt eine Art von 
                Regeln/Verträge an, z. B. was zu tun ist, aber sie erzwingt nicht  den "Wie"-Teil auf. 
            
                Außerdem sind Interfaces vorzuziehen, wenn Sie  versuchen, das Konzept der Mehrfachvererbung zu implementieren.
                Denken Sie daran, dass Sie, wenn Sie eine neue Methode in eine Schnittstelle aufnehmen wollen, 
                dann müssen Sie alle Implementierungen dieser Schnittstelle aufspüren 
                Schnittstelle aufspüren und die konkrete Implementierung für diese Methode 
                diese Methode an all diesen Stellen einfügen. In einem solchen Fall ist eine abstrakte Klasse 
                eine bessere Wahl, weil man eine neue Methode in einer abstrakten 
                Klasse eine neue Methode mit einer Standardimplementierung hinzufügen kann und der bestehende Code 
                reibungslos ablaufen.
             */

            #endregion
        }
    }

    #region Sample1 + Sample2 (Person : IDisposable)

    public interface IFSK18Check
    {
        bool CheckAge(Person alter);

        bool CheckAgeAlternativ(Person alter)
        {
            return alter >= 18 ? true : 
        }
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


    public class Person : IDisposable
    {
        public string Name
        {
            get;
            set;
        }

        public int Age { get; set; }

        public void Dispose()
        {
            Debug.WriteLine("Dispose wird gecalled");
        }
    }

    #endregion

    #region Sample 3 - Records + IEquatable

     public record Car (string Brand, string Model, int ConstructYear);


    #endregion

}