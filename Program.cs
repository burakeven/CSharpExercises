using System;
using System.Reflection;

namespace Reflection
    // -- ÇALIŞMA ANINDA -- Dinamik instance üretmek için kullanıyoruz.
{
    class Program
    {
        static void Main(string[] args)
        {
            //DortIslem dortIslem = new DortIslem(2,3); --- 15 numaralı satır ile aynı işlev
            //Console.WriteLine(dortIslem.Topla2());
            //Console.WriteLine(dortIslem.Topla(5, 6)); 
            var type = typeof(DortIslem);

            //Activator.CreateInstance(type); 10no'lu satır ile aynı işlevi görür.
            //DortIslem dortIslem=(DortIslem)Activator.CreateInstance(type,6,5); //10 nolu satır ile aynı işlevi görür.
            //Console.WriteLine(dortIslem.Topla(2, 3));
            //Console.WriteLine(dortIslem.Topla2());
            
            var instance=Activator.CreateInstance(type,6,5);
            MethodInfo methodInfo= instance.GetType().GetMethod("Topla2");
            Console.WriteLine(methodInfo.Invoke(instance, null));//invoke ile methodu çalıştırmış oluyoruz.
            Console.WriteLine("---------------");
            var methods = type.GetMethods();
            foreach (var item in methods)
            {
                Console.WriteLine("Method Adı: {0} ", item.Name);
                foreach (var item2 in item.GetParameters())
                {
                    Console.WriteLine("Parametre Adı: {0}", item2.Name);
                }
                foreach (var attribute in item.GetCustomAttributes())
                {
                    Console.WriteLine("Attribute Name: {0}", attribute.GetType().Name);
                }
            }

        }
    }
    class DortIslem
    {
        int _sayi1;
        int _sayi2;
        public DortIslem(int sayi1,int sayi2)
        {
            _sayi1 = sayi1;
            _sayi2 = sayi2;
        }
        public DortIslem()
        {
           
        }
        public int Topla(int sayi1,int sayi2)
        {
            return sayi1 + sayi2;
        }
        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
        public int Topla2()
        {
            return _sayi1 + _sayi2;
        }
        [MethodName("Carpma")]
        public int Carp2()
        {
            return _sayi1 * _sayi2;
        }
    }
    public class MethodNameAttribute : Attribute
    {
        private string v;

        public MethodNameAttribute(string v)
        {
            this.v = v;
        }
    }
}
