namespace Modul005_Funktionen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Main Methode kann in der Programm - Klasse nur mit anderen statische Methoden aufrufen.
            int summe1 = Addiere(3, 5);
            Console.WriteLine(summe1); //8

            //Überladen von Methoden 
            double summe2 = Addiere(3.6, 7.3);
            Console.WriteLine(summe2); //10.9 


            //Das PARAMS-Stichwort erlaubt die Übergabe einer beliebige Anzahl von gleichartigen Daten, welche innerhalb
            //der Methode als Array interpretiert werden
            int summe3 = BildeSumme(4, 5, 23, 54, 32, 1, 44, 123);
            Console.WriteLine(summe3);



            Subtraktion(11, 10, 9, 8);
            Subtraktion(11, 10, 9);
            Subtraktion(11, 10);
            //Subtraktion(11); //Fehler


            //Werte und Referenztypen


            //.NET Beispiel anhand int.tryParse

            int convertedValue;
            string numberAsString = "12345";
            string unvalidNumberAsString = "12345b";

            //Returnwert bool tryParse-> sagt aus, ob das conventieren in eine int-Variable geklappt hat 
            if (int.TryParse(numberAsString, out convertedValue)) 
            {
                //convertedValue ist 100% eine Zahl 

                Console.WriteLine(convertedValue);
            }
            else
                Console.WriteLine("Konventierung schlägt fehl");

            convertedValue = 0;

            if (int.TryParse(unvalidNumberAsString, out convertedValue))
            {
                Console.WriteLine(convertedValue);
            }
            else
                Console.WriteLine("Konventierung schlägt fehl");



            int differenz; //int Variable differenz hat hier die Speicheradresse: 0x123

            int summe4 = AddiereUndSubtrahiere(33, 11, out differenz);

            





            //int.TryParse()
            Console.WriteLine($"{differenz}");
            Console.WriteLine($"{summe4}");


            //Was sind Wertetypen: 
            //int, float, short, byte, bool, long (Alle Ganzzahltypen) + Gleitkomma-Datentypen (double, float, decimal) 
            //struct, enums
            //Wie verhält sich ein Wertetyp bei einer VariablenZuweisung?

            int meineOrginalVariable = 123;

            int meineDestinationVariable = meineOrginalVariable;

            meineDestinationVariable = 456;


            //Was ist ein Referenztyp:
            //class, interfaces, string

            
            

        }


        #region Methode und Überladung einer Methode

        //int Subtraktion(int a, int b)
        //{
        //    // Der RETURN-Befehl weist die Methode an einen Wert als Rückgabewert an den Caller zurückzugeben 
        //    return a - b;
        //}


        //Jede Funktion/Methode besteht aus einem Kopf und einem Körper. 
        //Der Kopf besteht aus den MODFIERN (private static) , dem Rückgabewert (int), den NAME (Addiere) sowie den Übergabeparametern 
        static int Addiere(int a, int b)
        {
            // Der RETURN-Befehl weist die Methode an einen Wert als Rückgabewert an den Caller zurückzugeben 
            return a + b;
        }

        //Funktion, welche den gleichen Bezeichner haben, nennt man ÜBERLADENE Funktionen. Diese müssen sich in Anzahl und/oder Art der 
        ///Übergabeparameter unterscheiden, damit der Aufruf eindeutig ist.
        static double Addiere(double a, double b)
        {
            //...
            return a + b;
        }


        //Kurzschreibweise einer Methode -> Geht nur bei Einzeiligen Methoden
        static float Addiere(float a, float b)
            => a + b;
        #endregion

        //Das PARAMS-Stichwort erlaubt die Übergabe einer beliebige Anzahl von gleichartigen Daten, welche innerhalb
        //der Methode als Array interpretiert werden
        static int BildeSumme(params int[] summanden)
        {
            int summe = 0;

            foreach (int summand in summanden)
                summe += summand; 

            return summe;
        }

        ///Wird einem Parameter mittels = -Zeichen ein Defaultwert zugewiesen wird dieser Parameter OPTIONAL und muss bei Aufruf nicht zwangs-
        ///läufig mitgegeben werden. OPTIONALE Parameter müssen am Ende der Parameter stehen.
        static double Subtraktion(int a, int b, int c = 0, int d = 0)
            => a - b - c - d;


        static int AddiereUndSubtrahiere (int a, int b, out int differenz) //Parametervariable differenz hat hier die Speicheradresse: 0x123 
        {
            differenz = a - b;
            return a + b;
        }


        static void MeinePersonMachtEtwas(Person p) //Speicheradresse wird übergeben (keine Kopie) 
        {

        }
    }


    public class Person
    {

    }


}