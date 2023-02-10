namespace SingleResponsibilityPrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    #region BadCode

    public class BadEmployeeClass
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Salary { get; set; }



        public void GenerateEmployeeReport(BadEmployeeClass badEmployee)
        {
            //Erste einen Bericht über den Mitarbeiter
        }

        public void InsertEmployeeInDatabase (BadEmployeeClass badEmployee)
        {
            //Speicher Datensatz in die DB
        }
    }
    #endregion

    #region Good Code

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public decimal Salary { get; set; }
    }

    public class ReportGenerator
    {

        public void Generate(Employee employee)
        {
            //Erstelle ein Report
        }

        //.... aber hier kommen nur Report spezifische Methoden rein. 
    }

    public class EmployeeRepository
    {
        public void Add(Employee employee)
        {
            //Mitarbeiter hinzufügen 
        }

        //public List<Employee> GetAll()
        //{
        //    return new List<Employee>(); //
        //}

        //Update-Methode

        //Delete-Methode
    }
    #endregion
}