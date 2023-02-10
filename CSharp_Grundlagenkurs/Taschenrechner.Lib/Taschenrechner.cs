#nullable disable 

using System.Diagnostics;

namespace Taschenrechner.Lib
{
    public class Calculator
    {

        #region Variante 1
        //ArguemntException wird verwendet, wenn es beim Parameter nicht um den erwarten Datentyp oder 'Wert' handelt
        public double Addition(double? a, double? b)
        {
            if (!a.HasValue) 
            {
                //Wir müssen eine Fehlermeldung generieren (eskalieren)
                //throw new ExceptionKlassen

                throw new ArgumentException($"Taschenrechner.Addition-> Parameter A ist NULL");
            }

            if (!b.HasValue)
            {
                //Wir müssen eine Fehlermeldung generieren (eskalieren)
                //throw new ExceptionKlassen

                throw new ArgumentException($"Taschenrechner.Addition-> Parameter B ist NULL");
            }

            return a.Value + b.Value;
        }


        public double Division(int? a, int? b)
        {
            if (!a.HasValue)
            {
                //Wir müssen eine Fehlermeldung generieren (eskalieren)
                //throw new ExceptionKlassen

                throw new ArgumentException($"Taschenrechner.Division-> Parameter A ist NULL");
            }

            if (!b.HasValue)
            {
                //Wir müssen eine Fehlermeldung generieren (eskalieren)
                //throw new ExceptionKlassen

                throw new ArgumentException($"Taschenrechner.Division-> Parameter B ist NULL");
            }
            else if (b.Value == 0)
                throw new DivideByZeroException();

            return a.Value / b.Value;
        }

        public void MethodeMitFehler()
        {
            int count = int.Parse("asdfsdf");
        }

        #endregion


        #region Variante 2

        //Dieses Beispiel fängt Fehler ab, 'loggt' diese und geben der Oberfläche eine definierte Fehlermeldung weiter(für den Kunden)
        public double Division2(double? a, double? b)
        {
            try
            {
                //In dieser Block kann ein Fehler passieren
                CheckParams(a, b);


                return a.Value / b.Value;
            } //Im Catch-Block werden die 'seltesten' Exceptions müssen oben stehen  
            catch (DivideByZeroException ex)
            {
                //Schreibe in eine Log-Datei

                Debug.WriteLine(ex.Message); //Geteilt durch Null geht nicht
                Debug.WriteLine(ex.StackTrace); // An welcher Stelle ist Fehler passiert und welche Methoden sind wir vor dem Fehler durchlaufen

                //Kombination beider
                Debug.WriteLine(ex.ToString()); //Message + StackTrace (beide werden ausgeegeben) 


                throw new CalculatorDllException("Zweiter Parameter beim Dividieren ist eine '0'");
            }
            catch (ArgumentException ex)
            {
                //Schreibe in eine Log-Datei
                Debug.WriteLine(ex.ToString());

                throw new CalculatorDllException("PArameterübergabe bei division2 ist NULL");
            }
            catch (Exception ex)
            {
                //Die Exception Klasse-ist die Basis-Klasse in der Hierarchy aller Exception - Klasse
                //Schreibe in eine Log-Datei
                Debug.WriteLine(ex.ToString());

                throw new CalculatorDllException("Unbekannter Fehler: " + ex.Message);
            }
            finally
            {
                //Aufräumarbeiten machen. 
                //Im Erfolg poder Im Fehlerfall wird dieser Codeblock immer ausgeführt. 
            }
        }

        private void CheckParams(double? a, double? b)
        {
            if (!a.HasValue)
            {
                //Wir müssen eine Fehlermeldung generieren (eskalieren)
                //throw new ExceptionKlassen

                throw new ArgumentException($"Taschenrechner.Division-> Parameter A ist NULL");
            }

            if (!b.HasValue)
            {
                //Wir müssen eine Fehlermeldung generieren (eskalieren)
                //throw new ExceptionKlassen

                throw new ArgumentException($"Taschenrechner.Division-> Parameter B ist NULL");
            }
            else if (b.Value == 0)
                throw new DivideByZeroException();

        }
        #endregion
    }


    public class CalculatorDllException : Exception
    {
        public CalculatorDllException(string message) 
            :base(message)
        { 
        
        }
    }
}