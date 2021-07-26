using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//RecordNotFoundException warning!
namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Find();
            }
            catch (RecordNotFoundException exception)
            {

                Console.WriteLine(exception.message);
            }
            catch(Exception exception)
            {

            }

            //------------------------------------------------------
            //Üsstekilerin aynısını bu yapıyor, methodlar ile don't repeat yourself kuralını uyguluyoruz.
            //HandleException(() => {Find()});
            HandleException(() =>
            {
                Find();
            });
            Console.ReadLine();

        }
        private static void HandleException(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {

                Console.WriteLine(exception.Message); ;
            }
        }
        private static void Find()
        {
            List<string> students = new List<string> { "Burak", "Buket", "Gaye" };
            if (!students.Contains("Buket"))
            {
                throw new RecordNotFoundException("RecordNotFound");
            }
            else
            {
                Console.WriteLine("Record found.");
            }
        }
    }
}
