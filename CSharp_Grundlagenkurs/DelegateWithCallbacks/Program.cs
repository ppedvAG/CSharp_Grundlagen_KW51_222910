using DelegateWithCallback.DrittanbieterDll;

namespace DelegateWithCallbacks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCryptComponent cryptComponent = new MyCryptComponent();

            MyCryptComponent.ProcessPercentDelegate processPercentDelegate = new MyCryptComponent.ProcessPercentDelegate(AktuelleProzentzahlAnzeige);
            MyCryptComponent.ProcessFinishDelegate processFinishDelegate = new MyCryptComponent.ProcessFinishDelegate(FinishAusgabe);
            MyCryptComponent.EncryptedFileResultDelegate encryptedFileResultDelegate = new MyCryptComponent.EncryptedFileResultDelegate(GetResultFile);
           


            cryptComponent.Encrypt("a", "b", processPercentDelegate, processFinishDelegate, encryptedFileResultDelegate);


        }


        static void AktuelleProzentzahlAnzeige(int percent)
            => Console.WriteLine(percent);

        static void FinishAusgabe(string msg)
            => Console.WriteLine(msg);


        static void GetResultFile(EncryptedFile file)
        {
            //Das kann als Return-Wert auch verwendet werden 
            
        }
    }
}