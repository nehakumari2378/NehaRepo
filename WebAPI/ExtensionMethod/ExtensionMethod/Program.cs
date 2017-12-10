using ExtensionMethod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExtensionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "neha";
            string result = str.ChangeStringCase();
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
