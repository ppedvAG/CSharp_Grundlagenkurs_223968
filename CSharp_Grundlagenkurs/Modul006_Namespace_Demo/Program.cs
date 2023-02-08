using DrittanbieterDll;
using MeinZweitesNamespace;
using Entities = Modul006_Namespace_Demo.Common.Entities;

namespace Modul006_Namespace_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Beispiel1 Zugriff auf das Enum  Anrede aus der DrittanbieterDll
            //Anrede anrede = Anrede.Frau;
            #endregion


            #region Bespiel2 Enum Anrede in zwei verschiedenen Namespace
            DrittanbieterDll.Anrede anrede2 = DrittanbieterDll.Anrede.Frau;
            MeinZweitesNamespace.Anrede anrede3 = MeinZweitesNamespace.Anrede.Mr;
            #endregion

            #region Beispiel3 Alias für Namespaces
            Entities.Person person = new Entities.Person();
            DrittanbieterDll.Person person2 = new Person();
            #endregion
        }
    }
}


