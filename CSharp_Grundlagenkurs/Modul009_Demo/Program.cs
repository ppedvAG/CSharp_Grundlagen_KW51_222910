using System.Security;

namespace Modul009_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Liste - Grundlagen
            //Was ist eine List<T> 
            List<string> cityListe = new List<string>();
            cityListe.Add("Berlin");
            cityListe.Add("Kaiserlautern");
            cityListe.Add("Bruchsal");

            Console.WriteLine("Wieviele Elemente befinden sich in eienr Liste: " + cityListe.Count); //3
            bool isAvailable = cityListe.Contains("Berlin");
            Console.WriteLine(isAvailable); //true 

            //Index Zugriff 
            for (int i = 0; i < cityListe.Count; i++)
            {
                string currentCity = cityListe[i]; //Indexzugriff (erstes Element hat den Index 0)
            }

            //Kopieren eine Liste in eine andere Liste

            List<string> cityListe2 = new List<string>();


            //AddRange möchte ein IEnumerable bekommen

            //Variante 1 
            cityListe2.AddRange(cityListe);

            //Variante 2
            cityListe2.AddRange(cityListe.ToArray());
            #endregion


            #region Polymoprhie-Beispiel


            List<Document> docListe = new List<Document>();

            docListe.Add( new PDFDocument());
            docListe.Add(new PDFDocument());
            docListe.Add(new WordDocument());
            docListe.Add(new JPEGDocument());

            //Alle Docuemnte in der Liste werden ausgedruckt
            foreach (Document currentDoc in docListe)
            {
                currentDoc.Print(); //Gemeinsamer Nenner alle Abgeleiteten Klassen -> abstrakte Methode

                //Ein JPEG-Document kann mit currentDoc nicht direkt auf die Eigenschaft CompressRate zugreifen. Das kennt die Klasse Document nicht
                if (currentDoc is JPEGDocument jpegDoc)
                {
                    Console.WriteLine($"Jpeg mit {jpegDoc.CompressRate} ");
                }

                if (currentDoc.GetType() == typeof(JPEGDocument))
                {
                    //Old Schooler 
                    JPEGDocument jpegDoc1 = (JPEGDocument)currentDoc;
                    jpegDoc1.Print();
                    jpegDoc1.CompressRate = 123;
                }
            }
            #endregion

            #region Polymorphie-Beispiel 2
            List<MyTextDocumentBase> docListe2 = new List<MyTextDocumentBase>();

            docListe2.Add(new MyTextDocumentVersion1());
            docListe2.Add(new MyTextDocumentVersion2());
            docListe2.Add(new MyTextDocumentVersion2());
            docListe2.Add(new MyTextDocumentVersion3());

            //PDFDocument stammt nicht von MyTextDocument ab 
            //docListe2.Add(new PDFDocument());

            foreach(MyTextDocumentBase myTextDoc in docListe2) 
            {
                myTextDoc.Print();
                myTextDoc.GetVersion();
            }

            foreach(Document currentDoc3 in docListe2)
            {
                currentDoc3.Print();
            }

            //Das würde gehen MyTextDocumentBase stammt von Document
            docListe.AddRange(docListe2);
            #endregion


        }
    }


    public abstract class Document
    {
        public abstract void Print();
    }


    

    public class PDFDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("PDF wird gedruckt");
        }
    }


    

    public class JPEGDocument : Document
    {
        public int CompressRate { get; set; }
        public override void Print()
        {
            Console.WriteLine("JPG wird gedruckt");
        }
    }

    public class WordDocument : Document
    {
        public override void Print()
        {
            Console.WriteLine("Word wird gedruckt");
        }
    }




    public abstract class MyTextDocumentBase : Document
    {
        public abstract string GetVersion();
    }

    public class MyTextDocumentVersion1 : MyTextDocumentBase
    {
        public override string GetVersion()
        {
            return "1.1";
        }

        public override void Print()
        {
            Console.WriteLine("MyTextDocumentVersion1");
        }
    }

    public class MyTextDocumentVersion2 : MyTextDocumentBase
    {
        public override string GetVersion()
        {
            return "2.1";
        }

        public override void Print()
        {
            Console.WriteLine("MyTextDocumentVersion2");
        }
    }

    public class MyTextDocumentVersion3 : MyTextDocumentBase
    {
        public override string GetVersion()
        {
            return "3.2.1";
        }

        public override void Print()
        {
            Console.WriteLine("MyTextDocumentVersion3");
        }
    }
}