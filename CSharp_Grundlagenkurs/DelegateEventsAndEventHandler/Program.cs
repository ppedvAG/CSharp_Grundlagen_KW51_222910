namespace DelegateEventsAndEventHandler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Sample1 - Component1
            MyComponent myComponent = new MyComponent();

            //Optionale Verwendung -> eben das was der Kunde benötigt
            myComponent.ChangePercentValue += MyComponent_ChangePercentValue;
            myComponent.ResultDelegate += MyComponent_ResultDelegate;

            myComponent.StartProcess();

            #endregion


            Component2 component2 = new Component2();
            component2.ProcessCompleted += Component2_ProcessCompleted;
            component2.PercentValueChanged += Component2_PercentValueChanged;
            component2.PercentValueChanged2 += Component2_PercentValueChanged2;
        }

        private static void Component2_PercentValueChanged2(object? sender, MyPercentEventArgs e)
        {
            Console.WriteLine(e.PercentValue);
        }

        private static void Component2_PercentValueChanged(object? sender, EventArgs e)
        {
            if (e is MyPercentEventArgs myPercentEventArgs)
                Console.WriteLine(myPercentEventArgs.PercentValue);
        }

        private static void Component2_ProcessCompleted(object? sender, EventArgs e)
        {
            Console.WriteLine("Sind fertig");
        }


        #region Sample1 - Component1
        private static void MyComponent_ResultDelegate(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void MyComponent_ChangePercentValue(int percentValue)
        {
            Console.WriteLine(percentValue);
        }
        #endregion


        #region Sample2 - Component2



        #endregion
    }



    #region Component1

    public delegate void ChangePercentValueDelegate(int percentValue);
    public delegate void ResultDelegate(string msg);

    public class MyComponent
    {
        //Die Komponente bietet nach draußen, zwei Events an 
       
        //Wir können diesen delegates eine Methode übergeben oder auch nicht (Die frage ist, was der Kunde eben für Informationen haben möchte) 

        public event ChangePercentValueDelegate ChangePercentValue;
        public event ResultDelegate ResultDelegate;

        public void StartProcess(/*Es werden keine Parameter übergben*/)
        {
            for (int i = 0; i <= 100; i++)
            {
                //Prozentzahl muss nach außen kommuniziert werden 

                //Hat diese event Delagte eine Methode (von außen) abgebunden
                if (ChangePercentValue!= null)
                {
                    ChangePercentValue(i);
                }
            }


            //Ausgabe, dass wir fertig sind

            if (ResultDelegate != null)
                ResultDelegate("fertig");
        }
    }

    #endregion

    #region Component2

    public class Component2
    {
        //EventHandler ist von Delegate und können bei PercentValueChanged und ProcessCompleted eine Methode von außen hinzufügen
        public event EventHandler PercentValueChanged;

        public event EventHandler<MyPercentEventArgs> PercentValueChanged2;


        public event EventHandler ProcessCompleted;

        public void StartProcess()
        {
            for (int i = 0; i <= 100; i++)
            {
                if (PercentValueChanged!= null)
                {
                    PercentValueChanged.Invoke(this, new MyPercentEventArgs() { PercentValue = i });

                }

                OnPercentValueChanged(i);


            }

            //Rufen die Methode auf, die am event EventHandler dran hängt
            ProcessCompleted.Invoke(this, EventArgs.Empty); //Wir senden nur ein Signal, dass wir fertig sind (Parameterlos)
        }


        protected virtual void OnPercentValueChanged(int i)
        {
            //Hier wird geprüft ist PercentValueChange ungleich 'Null';
            PercentValueChanged?.Invoke(this, new MyPercentEventArgs() { PercentValue = i });
        }
    }

    public class MyPercentEventArgs : EventArgs
    {
        public int PercentValue { get; set; }
    }

    #endregion
}