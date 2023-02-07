using System;

namespace Modul004_Schleifen_Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Schleifen
            #region While-Schleife

            // Beispiel 1
            int i = 0;

            while (i < 10)
            {
                Console.WriteLine(i);
                i++;
            }


            //Endlosschleife
            while (true)
            {
                Console.WriteLine("Hauptmenü:");
                Console.WriteLine("(1) Optionen");
                Console.WriteLine("(2) Help/Docs");
                Console.WriteLine("(E) Exit");

                Console.Write("> ");
                ConsoleKeyInfo inputKey = Console.ReadKey();
                
                if (inputKey.Key == ConsoleKey.E)
                {
                    Console.WriteLine("Auf Wiedersehen");
                    break; //Breche die Schleife ab, 
                }
            }
            #endregion

            #region do while

            int meineZahl;
            string input2 = string.Empty;


            do
            {
                Console.Write("Geben Sie Bitte eine Zahl ein: ");
                input2 = Console.ReadLine();

            } while (!int.TryParse(input2, out meineZahl));

            //meineZahl beinhaltet die eingebene valide Zahl von input2
            Console.WriteLine($"Zahl ist {meineZahl}");
            #endregion



            #region for-Schleife
            // Die Zählschleife

            for (int counter = 0; counter < 10; counter++) 
            {

                
                //Wenn die Zahl ungerade ist, starte gleich den nächsten Schleifendurchlauf und vergesse den Rest
                if (counter % 2 != 0)
                    continue;

                //wir wollen nur die Gerade-Zahlen ausgeben 
                Console.WriteLine(counter);
            }

            //for(;true;)
            //{

            //}


            //for (int cnt = 0;true;cnt=cnt+2)
            //{
            //    cnt++;

            //}


            #endregion

            #region foreach - Durchblättern durch Listen / Array
            
            int[] myArray = { 3, 6, 9, 2, 4, 6, 8 };


            //Wenn ein Datensatz oder Eintrag in myArray sich befindet, wird der foreach-Loop ausgeführt 
            foreach(int currentValue in myArray)
            {
                Console.WriteLine(currentValue);
            }


            #endregion
            #endregion


            #region Quizrunde (Variable++)
            int myVariable = 15;

            Console.WriteLine(myVariable++); //15
            
            myVariable = 15;    
            Console.WriteLine(++myVariable); //16
            #endregion

            #region Enums

            #region Wie wurde vor der Zeit von Enums Programmiert?
            
            string[] meineWochentage = { "Mo", "Di", "Mi", "Do", "Fr", "Sa", "So" };

            //Wenn ich den Samstag ausgeben möchte, müsste ich das bei einem Array so schreiben:

            string lieblingsTag = meineWochentage[4];
            Console.WriteLine(meineWochentage[4]); // Ist unübersichtlicht, weil wir wissen müssen, welcher Eintrag mit dem Indexwert 5 steht
            #endregion


            //Deklaration und Initialisierung einer Variablen vom Enumerator-Typ
            Wochentag meinLieblingstag = Wochentag.Fr;
            Console.WriteLine($"Dein lieblingstag ist {meinLieblingstag}");


            Console.WriteLine("Welcher Wochentag ist dein Lieblingstag?");


            //For-Schleife über die möglichen Zustande des Enumerators
            for (int index = 1; index <= 7; index++)
            {
                Console.WriteLine($"{index}: {(Wochentag)index}");
            }


            //Speichern einer Benutzereingabe (Int) als Enumerator
            //Cast: Int -> Wochentag
            meinLieblingstag = (Wochentag)int.Parse(Console.ReadLine());
            Console.WriteLine($"Dein lieblingstag ist {meinLieblingstag}");


            //Parsing eines Strings in den Enumzustand
            meinLieblingstag = (Wochentag)Enum.Parse(typeof(Wochentag), "Mi");


            switch(meinLieblingstag)
            {
                case Wochentag.Mo:
                    Console.WriteLine("Wochenstart");
                    break;
                case Wochentag.Di:
                case Wochentag.Mi:
                case Wochentag.Do:
                    Console.WriteLine("Normaler Wochentag");
                    break;
                case Wochentag.Fr:
                case Wochentag.Sa:
                case Wochentag.So:
                    Console.WriteLine("Wochenede");
                    break;
                default:
                    Console.WriteLine("Fehlerhafte Eingabe");
                    break;
            }

            int zahl = -45;

            switch(zahl)
            {
                case 5:
                    Console.WriteLine("zahl ist 5");
                    break;
                case int z when z < 0:
                    Console.WriteLine("zahl < 0");
                        break;
                default:
                    break;
            }


            #endregion
        }
    }

    enum Wochentag { Mo=1, Di, Mi, Do, Fr, Sa, So}
    enum Anrede { Herr, Dame, Diverse }
    
    enum Jahrezeiten { Frühling, Sommer, Herbst, Winter}
}