using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate void MyDelegate();//Void olan ve parametre almayan methodlara delegelik yapar.
    public delegate void MyDelegate2(string text);//void olan ve string değer döndüren methodlara delegelik yapar.
    public delegate int MyDelegate3(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            CustomManager customManager = new CustomManager();
            //customManager.SendMessage();
            //customManager.ShowAlert();
            MyDelegate myDelegate = customManager.SendMessage;
            myDelegate += customManager.ShowAlert;
            myDelegate -= customManager.SendMessage;
            myDelegate(); //delegeyi çağırmadan işlem gerçekleşmiyor.
            Console.WriteLine("--------------");
            MyDelegate2 myDelegate2 = customManager.SendMessage2;
            myDelegate2 += customManager.ShowAlert2;
            myDelegate2("hello");

            newMaths math = new newMaths();
            MyDelegate3 myDelegate3 = math.Topla;
            var result=myDelegate3(2,5);
            Console.WriteLine(result);
            

            Console.ReadLine();
        }
    }
    public class CustomManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Message has been sended.");
        }
        public void ShowAlert()
        {
            Console.WriteLine("Be Careful!");
        }

        public void SendMessage2(string message)
        {
            Console.WriteLine(message);
        }
        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);
        }
    }
    public class newMaths
    {
        public int Topla(int x, int y)
        {
            return x + y;
        }
        public int Carp(int x, int y)
        {
            return x * y;
        }
    }
}
