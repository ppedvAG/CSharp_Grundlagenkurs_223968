using Microsoft.Data.SqlClient;

namespace Modul007_IDisposable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("any ConnectionString");
            FileStream fileStream = new FileStream("Haribo.txt", FileMode.Open);
            
            
            //Der Finally - Block hat die Aufgabe Ressource wieder freizugeben 
            try
            {
                //Hier Können Fehler passieren
                conn.Open(); //SQL VErbindung wird aufgebaut 

                //Szenario: 
                //Wir würden hier eine Import-Routine einbauen -> Es würde ein Fehler passieren!!!
            }
            catch(Exception ex) 
            { 
                //Dann werden die Fehler hier mitgeteilt
            }
            finally
            {
                //Hier werden die Strukturen expliziet abgebaut. Die im Try-Block verwendet werden 
                //Finally wird immer aufgerufen (auch im Fehlerfall) 
                conn.Close();

                fileStream.Flush();
                fileStream.Close();
            }


            //Ab .NET 3.0 (3.5) -> wurde der using - Befehl eingefürt


            using (SqlConnection conn1 = new SqlConnection("any ConnectionString"))
            {
                conn1.Open();
            } //Dispose wird aufgerufen -> Ressourcen (Handler, Connection) werden abgebaut oder freigegeben -> Das bedeutet noch nicht, dass hier ein Objekt zerstört wird


        }
    }
}