namespace Modul008_Demo_VirtualOverrideSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
           ElektroArtikel elektroArtikel = new ElektroArtikel("E-1234", 3);


            Console.WriteLine(elektroArtikel.ArtikelLabel());
        }
    }

    public class Artikel
    {


        private decimal price; 
        //Virtuale Property
        public virtual string ArtikelNr { get; set; }

        public int Garantie { get; set; } = 0;

        public decimal Price 
        { 
            get
            {
                return price;
            }

            set
            {
                if (value > 0)
                    price = value;
                else
                    throw new ArgumentException(); //Fehlermeldung (Falscher Wert) 
            }

        }


        public Artikel(string artikelNr, decimal price, int garantie)
        {
            ArtikelNr = artikelNr;
            Garantie = garantie;
            Price = price;
        }


        public virtual string ArtikelLabel()
        {
            return Garantie != 0 ? $"ArtikelNr: {ArtikelNr} hat eine Preis von {Price} und eine Garantie von {Garantie} Jahren" : $"ArtikelNr: {ArtikelNr} hat eine Preis von {Price}";
        }
    
        //Virtuale Methode

    }

    public class ElektroArtikel : Artikel
    {
        public ElektroArtikel(string artikelNr, decimal price,  int garantie=2)
            :base(artikelNr, price, garantie)
        {

        }

        public override string ArtikelNr 
        { 
            get => base.ArtikelNr; 
            
            set
            {

                if (value.StartsWith("E-"))
                    base.ArtikelNr = value;
            }
        }

        public override string ArtikelLabel()
        {
            return $"Eletro-Artikel: {ArtikelNr} hat eine Garante von {Garantie} - (oder mindestens 2 Jahre}} und kostet {Price}";
        }
    }

    public class ApothekenProdukte : Artikel
    {
        public ApothekenProdukte(string artikelNr)
            : base(artikelNr, 10, 0)
        {

        }
    }

}