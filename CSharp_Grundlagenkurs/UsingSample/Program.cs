using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace UsingSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using - Statement garantiert das aufrufen von der Dispose-Methode der jeweiligen instanz z.B
            //z.B: -> SqlConnection conn = new SqlConnection ....

            SqlConnection conn = new SqlConnection("any connectionstring");
            
            try
            {
                conn.Open();

                //Es passiert ein fehler oder nicht 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally //wird immer ausgeführt 
            {
                conn.Close();
            }


            FileStream fileStream = new FileStream("abc.txt", FileMode.Open);

            try
            {
                //fileStream.Write("haribo ist toll");
            }
            catch (Exception ex)
            {
                //Fehler
            }
            finally
            {
                fileStream.Flush(); //Schreibe noch alles raus, was du im Buffer hast 
                fileStream.Close(); //Hier wird die Datei in Windows auch freigegeben (File-Handler) 
            }

            using (SqlConnection conn1 = new SqlConnection("any connectionstring"))
            {
                conn.Open();


            }//conn.Dispose() automatisch aufgerufen - um das Abbauen der Connection zu garantiert. 



            using (FileStream fileStream1 = new FileStream("abc.txt", FileMode.Open))
            {
                
            }//filestream.Dispose() -> da drin wird gekümmert, dass FileHandler freigegeben wird


            using (Cat cat1 = new Cat())
            {
                try
                {

                }
                catch (Exception ex)
                {

                }

                //Auf finally können wir verzichen
            } //cat.Dispose() 
        }


    }

    public class Cat : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Ressourcen bauen wir hier ab");
        }
    }
}