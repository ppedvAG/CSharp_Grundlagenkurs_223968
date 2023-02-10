namespace OpenClosePrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Salary { get; set; }
    }


    #region BadCode 

    public class BadReportGenerator
    {
        public string CrystalReportVorlagenPfad { get; set; }   
        public string List10ReportVorlagenPfad { get; set; }


        //switch  x 2
        public void GenerateReport(Employee employee, int typeOfReport) 
        { 
        
            if (typeOfReport== 1)
            {
                //Crystal Reports -> Hierfür wird eine DLL verwendet mit ganz vielen Funktionen, die man verwenden 
                //Wasserzeichen, Vorlagen für Berichte, Speicherort -> Mitarbeiter-Berichte
            }
            else if (typeOfReport== 2)
            {
                //List10 -> REports -> Gierfür wird auch eine DLL verwendet 
                //Digitalen Signatur // Komprimierung // Reports in Cloud speicher
            }
            else if (typeOfReport == 3)
            {
                //PDF - Bericht 
                //Wasserzeichen,CompressRate 
            }
            else
            {
                //Type of Report unbekoannt 
            }
        }
    }
    #endregion


    //Open-Party

    public abstract class ReportGernatorBase
    {
        public abstract void Generate(Employee employee);
    }

    //Close-Part
    public class CrystalReportGenerator : ReportGernatorBase
    {
        //Weitere Platz für Crystal-Spezifische- Properties

        public override void Generate(Employee employee)
        {
             //Erstelle ein Report
        }

        //... weitere zu Crystal-Reports
    }

    public class List10ReportGenerator : ReportGernatorBase
    {
        public override void Generate(Employee employee)
        {
            //Erstelle List10 Reports 
        }
    }


    public class MyApp
    {
        public void GenerateReport (int reporttype)
        {
            ReportGernatorBase report;
            switch (reporttype)
            {

                case 1:
                    report = new CrystalReportGenerator();
                    break;
                case 2:
                    report = new List10ReportGenerator();
                    break;

            }
        }
    }




}
