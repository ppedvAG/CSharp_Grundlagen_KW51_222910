namespace DelegateWithCallback.DrittanbieterDll
{
    //Callbacks werden verwenden um nach draußen Informationen anzubieten oder um eine fertig Struktur am Ende zu übermitteln 

    public class MyCryptComponent
    {
        public void Encrypt(string orginalFile, string encryptedFile, ProcessPercentDelegate percentDelegate, ProcessFinishDelegate finishDelegate, EncryptedFileResultDelegate resultFileDelegate)
        {
            for (int i = 0; i <= 100; i++)
            {
                //Einmal wollen wir nach draußen mitteilen, wie weit der Verschlüsselungsprozess gekommen ist

                
                percentDelegate(i);
            }

            //Wollen wir nach draußen mitteilen, dass wir fertig mit der Verschlüsselung sind

            finishDelegate("fertig");
            

            EncryptedFile resultFile = new EncryptedFile();

            //EncryptedFile ist die Rückgabe via Callback
            resultFileDelegate(resultFile);
        }
        


        //NestedTyp 
        public delegate void ProcessPercentDelegate(int currentPercentValue);
        public delegate void ProcessFinishDelegate(string msg);



        public delegate void EncryptedFileResultDelegate(EncryptedFile encryptedFile);
    }

    public class EncryptedFile
    {
        //....

        public Guid Id { get; set; } = Guid.NewGuid();  
    }
}