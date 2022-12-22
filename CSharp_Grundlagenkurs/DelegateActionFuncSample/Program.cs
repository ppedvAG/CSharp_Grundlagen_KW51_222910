using System;

namespace DelegateActionFuncSample
{
    //Delegates benötigen eine Methode
    //Die zu verwendete Methode muss die selbe Signatur (Returntyp + Parameterliste verwenden) vorweisen, wie das Delegate 
    //Ein Delegate kann eine Methode aufrufen.  

    public delegate int ChangeNumberDelegate(int number);

    public delegate void LogDelegate(string message);   

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Delegates
            //Sample1: 
            //Ein Delegate ist ein Datentyp den man definieren kann (siehe oberhalb der Klasse Program -> )
            #region Was ist ein Delegate? 

            //Methode dem Delgate hinzufügen:
            //Funktionszeiger der Methode wird dem Delegate übergeben. Das Delegate weiß, egal wo es im Programm sich befindet, die hinzugefügte Methode aufzurufen
            ChangeNumberDelegate chanceNumberDelegate = new ChangeNumberDelegate(ChangeNumerOffSet5);

            int result = chanceNumberDelegate(50);
            Console.WriteLine(result); //55


            //Sample2: 

            LogDelegate logDelegate = new LogDelegate(WriteDbLog);
            logDelegate("Logeintrag");

            #endregion

            #region Delegates können += oder -= Operatoren 


            //Sample 1:
            chanceNumberDelegate += ChangeNumerOffSet10;
            chanceNumberDelegate += ChangeNumerOffSet15;


            //Es werden alle Methoden gecalled->Allerdings wird nur das Return-Ergebnis der letzten Methode zurückgegeben 
            result = chanceNumberDelegate(50);
            Console.WriteLine(result); //65 (bekommt nur von ChangeNumerOffSet15)

            //Sample2: Wir bekommen wir jeden Returnwert zurück geliefert?

            //Durch die Foreach - Schleife können wir jeden Funktionszeiger durchgehen und dadurch jede Methode aufrufen und deren Rückgabewert auslesen 
            result = 0;
            foreach (Delegate currentDelegate in chanceNumberDelegate.GetInvocationList()) 
            {
                result = (int)currentDelegate.DynamicInvoke(result);
            }

            Console.WriteLine(result); //30


            #endregion
            #endregion

            #region Action
            //Was ist ein Action-Delegate? 
            //Action Delegate ist ein generisches Delegate und kann nur Methoden verwenden, die ein void - als Rückgabetyp 

            Action<string> actionDelegate = new Action<string>(WriteDbLog);
            actionDelegate("Hallo Welt");



            //+= und -= kann Action-Delagates auch und kann auch multiple Methoden genauso aufrufen, wie bei dem vorigen Beispiel von Delegates 
            actionDelegate += WriteFileLog;

            foreach (Delegate currentDelegate in actionDelegate.GetInvocationList())
            {
                currentDelegate.DynamicInvoke("Ein Logeintrag");
            }

            #endregion

            #region Func
            //Func-Deelgate kann mit Methoden zusammenarbeiten, die ein Returnwert haben
            //Bei Func steht der Returntyp an letzter Stelle -> Func(Parametertyp1, Parametertyp2, RETURNTYP);
            Func<int, int> changeNumbDel = new Func<int, int>(ChangeNumerOffSet5);

            result = changeNumbDel(50);

            Console.WriteLine(result);
            #endregion
        }

        public static int ChangeNumerOffSet5(int number)
        {
            return number+=5;
        }

        public static int ChangeNumerOffSet10(int number)
        {
            return number += 10;
        }

        public static int ChangeNumerOffSet15(int number)
        {
            return number += 15;
        }


        public static void WriteDbLog(string message) 
        {
            Console.WriteLine(message);
        }

        public static void WriteFileLog(string message)
        {
            Console.WriteLine(message);
        }




    }
}
