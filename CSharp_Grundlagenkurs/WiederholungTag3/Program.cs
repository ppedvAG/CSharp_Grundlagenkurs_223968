namespace WiederholungTag3
{
    

    #region Vererbung mit Modifier
    //https://learn.microsoft.com/de-de/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers

    public class BaseClass
    {
        public string BaseProperty { get; set; }
        internal string BaseProperty2 { get; set; }

        private string BaseProperty3;

        protected string BaseProperty4 { get; set; }


        public void BaseMethode ()
        {
            Console.WriteLine("Eine Basis-Methode");
            
        }

        private void BaseMethod2()
        {
            Console.WriteLine("Eine private Basis-Methode");
        }

        protected void BaseMethod3() 
        {
            Console.WriteLine("eine protected Basis-Methode");
        }
    }

    public class AbgeleitedeKlasse : BaseClass
    {
        public AbgeleitedeKlasse(string property)
        {
            BaseProperty = property;
            BaseProperty2 = property;
            //BaseProperty3 = property;

        }


        public void CallBaseMethoden()
        {
            BaseMethode(); //public - Methode
            BaseMethod3(); //protected - Methode
        }
    }

    #endregion
}

namespace Beispiel2
{
    #region Multiple Basisklassen 
    //Jede Basisklasse repräsentiert die Basis eines Themas 
    public class Basisklasse1
    {
        public void BasisKlasse1_Methoden1()
        {
            Console.WriteLine("BasisKlasse1_Methoden1");
        }
    }

    public class Basisklasse2
    {
        public void BasisKlasse1_Methoden1()
        {
            Console.WriteLine("BasisKlasse1_Methoden1");
        }
    }

    public class AbgeleiteteKlasse : Basisklasse1
    {

    }


    //Gitb eine Fehlermeldungh
    //public class NextAbgeleiteteKlasse : AbgeleiteteKlasse, Basisklasse2
    //{

    //}
    #endregion

}


namespace Beispiel3
{
   



    #region Warum gibt es Default-Implementierungen bei interfaces 

    public interface IMulitCalc
    {
        public double Multiplikation(double? a, double? b)
        {
            Console.WriteLine("IMulitCalc.Multiplikation");
            if (!a.HasValue)
                throw new ArgumentException();

            if (!b.HasValue)
                throw new ArgumentException();

            return a.Value * b.Value;
        }

    }

    public class ClassImpl : IMulitCalc
    {
        
    }

    public class ClassImpl1 : IMulitCalc
    {
       
    }

    public class ClassImpl2 : IMulitCalc
    {
        //public double Multiplikation(double? a, double? b)
        //{
        //    Console.WriteLine("ClassImpl2 ");
        //    if (!a.HasValue)
        //        throw new ArgumentException();

        //    if (!b.HasValue)
        //        throw new ArgumentException();

        //    return a.Value * b.Value;
        //}
    }
    #endregion


   


   






    public interface IAddition
    {
        int Addition(int a, int b); //wird in der verwendeten Klasse zu einer Public Methode
    }

    public interface ISubtraktion
    {
        int Sub(int a, int b);
        
    }

    public interface IMultiplikation
    {
        int Multiplikation(int a, int b);
    }

    public interface IDivision
    {
        float Division(float a, float b);
    }


    public class Taschenrechner : IAddition, ISubtraktion, IMultiplikation, IDivision
    {

        public int Addition(int a, int b)
        {
            return a + b;
        }

        public float Division(float a, float b)
        {
            return a / b;
        }

        public int Multiplikation(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Sub(int a, int b)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITaschenrechner : IAddition, ISubtraktion, IMultiplikation, IDivision
    {

    }
    

    public class Taschenrechner2 : ITaschenrechner
    {
        public int Addition(int a, int b)
        {
            throw new NotImplementedException();
        }

        public float Division(float a, float b)
        {
            throw new NotImplementedException();
        }

        public int Multiplikation(int a, int b)
        {
            throw new NotImplementedException();
        }

        public int Sub(int a, int b)
        {
            throw new NotImplementedException();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Warum Default-Implementierungen? 
            //Aufruf der Methode -> Variante 1 -> Basistyp ist ClassImpl 
            ClassImpl classImpl = new ClassImpl();
            
            if (classImpl is IMulitCalc classWithMultiCalcMethode)
            {
                classWithMultiCalcMethode.Multiplikation(5, 5);
            }

            //Variante 2 -> Interface als Basistyp 
            IMulitCalc multiCalc = new ClassImpl();
            multiCalc.Multiplikation(6, 5);


            //Basistyp
            ClassImpl2 classImpl1 = new ClassImpl2();
            //classImpl1.Multiplikation(5, 5);

            if(classImpl1 is IMulitCalc multicalc1)
            {
                multicalc1.Multiplikation(6, 5);
            }

            IMulitCalc mulitCalc1 = new ClassImpl2();
            mulitCalc1.Multiplikation(2, 3);
            #endregion


            Taschenrechner taschenrechner = new Taschenrechner();
            taschenrechner.Addition(5, 5);
            taschenrechner.Sub(4, 3);

            ITaschenrechner taschenrechner2 = new Taschenrechner2();
            taschenrechner2.Addition(5, 6);
            taschenrechner2.Sub(5, 4);


            IAddition additionTaschenrechner = new Taschenrechner2();
            additionTaschenrechner.Addition(6, 7);
        }
    }
}