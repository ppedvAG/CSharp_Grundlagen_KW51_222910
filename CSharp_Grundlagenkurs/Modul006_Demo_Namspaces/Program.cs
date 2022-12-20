using ZweitesNamespace;
using DrittesNamespace;

//Thirs ist ein Alias von DrittesNamespace
using Third = DrittesNamespace;
using DrittanbieterDll;
namespace Modul006_Demo_Namspaces
{

    //Innerhalb eines Namespaces müssen die definierten Datentypen einen eindeutigen Namen vorweisen
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Damit ich das Enum Wochentag verwenden kann muss ich: using ZweitesNamespace einfügen
            Wochentag wochentag = Wochentag.Di;

            //Das Enum Anrede kommt mehrmals vor. Hier können wir Explizet (mithilfe der Namespace-Angabe) hinschreiben, welches Enum gemeint 
            ZweitesNamespace.Anrede AnredeAusZweitenNameSpace = ZweitesNamespace.Anrede.Divers;
            DrittesNamespace.Anrede AnredeAusDriteNameSpace = DrittesNamespace.Anrede.Dr;

            Third.Anrede AnredeMitAlias  = Third.Anrede.Prof;
            //Wir können auch Namespaces mit Aliase verkürzen 


            //Jahreszeiten kann augelöst werden, weil es 1x vorliegt (anhand der usings + eigenen Namespace) 
            Jahreszeiten jahreszeiten = Jahreszeiten.Winter;

            //Da es mehrere Enums mit Anrede aktuell geben kann, muss man expliziet sagen, welches Anrede-Enum verwendet werden soll
            DrittanbieterDll.Anrede anrede = DrittanbieterDll.Anrede.Herr;




        }
    }

    
    public enum Anrede { Herr, Frau }
}

#region Namespace Beispiele
namespace ZweitesNamespace
{
    public enum Anrede { Herr, Frau, Divers }

    public enum Wochentag {  Mo, Di, Mi, Do, Fr, Sa, So}

}

namespace DrittesNamespace
{
    public enum Anrede { Herr, Frau, Divers, Dr, Prof }
}

#endregion


