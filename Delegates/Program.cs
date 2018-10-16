using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{

    public delegate string FirstDelegate(int x);

//    Func<int, string> = 

    class Program
    {
        public string name;

        public Program (string pName)
        {
            name = pName;
        }

        public static void Main()
        {
// Using the old .Net 1/1.1 syntax

            FirstDelegate d1 = new FirstDelegate(Program.StaticMethod);

            Program instance = new Program("Created my instance");

            instance.name = "My instance";
            FirstDelegate d2 = new FirstDelegate(instance.InstanceMethod);


            Console.WriteLine(d1(10)); // Writes out "Static method: 10"
            Console.WriteLine(d2(5));  // Writes out "My instance: 5"

//  Using new simplified syntax

            FirstDelegate n1 = StaticMethod;
            FirstDelegate n2 = (new Program ("Instance new way")).InstanceMethod;
        
            Console.WriteLine(n1.Invoke(88));
            Console.WriteLine(n2.Invoke(22));

            Console.WriteLine(n1(101));  // Writes out "Static method: 10"
            Console.WriteLine(n2(102));  // Writes out "My instance: 5"


            Dictionary<string, string> dc1  = new Dictionary<string, string>();
            dc1.Add("Yuriy", "Gruzglin");
            dc1.Add("Anna", "Montana");
            dc1.Add("Joy", "Bennet");
            dc1["Stella"] = "Artoit";

            dc1.Append(new KeyValuePair<string, string>("Gerald", "Ford"));
            dc1.Append(new KeyValuePair<string, string>("Ray", "Holmes"));

            foreach (KeyValuePair<string, string> z in dc1)
                Console.WriteLine(z.Key + "   " + z.Value);

            string y;

            if (dc1.TryGetValue("Joy", out y))
                Console.WriteLine("Joy  " + y);

            Console.ReadLine();
        }

        static string StaticMethod(int i)
        {
            return string.Format("Static method: {0}", i);
        }

        string InstanceMethod(int i)
        {
            return string.Format("{0}: {1}", name, i);
        }
    }
}
