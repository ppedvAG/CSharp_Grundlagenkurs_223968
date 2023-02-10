namespace LizkovischePrinciple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }


    #region Bad Code

    public class BadErdbeere
    {
        public string GetColor()
            => "rot";
    }

    public class BadKrische : BadErdbeere
    {
        public string GetColor
            => base.GetColor();
    }
    #endregion


    #region Good Code

    public abstract class Fruits
    {
        public abstract string GetColor();
    }

    public class Erdbeere : Fruits
    {
        public override string GetColor()
        {
            return "rot";
        }
    }

    public class Krische : Fruits
    {
        public override string GetColor()
        {
            return "rot";
        }
    }

    #endregion
}