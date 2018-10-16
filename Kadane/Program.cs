using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kadane
{
    class Program
    {

        Func<string, int, int, string> nf0 = (s, i1, i2) => { return s + ": " + (i1 ^ 2 + i2 ^ 2);  };

// Drive code 
        public static void Main()
        {
            int exitCode = -1;

            long memoryBefore = GC.GetTotalMemory(true);
            Func<string, int, int, string> nf0 = (s, i1, i2) => { return s + ": " + (i1^2 + i2^2); };

            Console.WriteLine(nf0("hello", 2, 3));

//============  Kadane algorithm  ==============

//          int[] a = { -2, -3, 4, -1, -2, 1, 5, -3 };
            int[] a = { 1100, -30, -450, -560, 2000, 1, 5, -3 };
//          int[] a = { -1100, -30, -450, -560, -2000, -1, -5, -3 };

            var tplRet = maxSubArraySum2(a);
//          Console.Write("Maximum contiguous sum is  [1] " + maxSubArraySum(a) + "   [2] " + maxSubArraySum2(a));

            Console.Write("S2 " + tplRet.S + "   X1 " + tplRet.X1 + "   X2 " + tplRet.X2 + "      S " + maxSubArraySum(a));


/*  ====   Small experiment with Func type to explore delegates  ============
    https://stackoverflow.com/questions/4285584/how-many-interfaces-are-allowed-to-be-implemented

            int iterations = (int)Math.Pow(2, 8) + 1;

            Func<int, string> getInterfaceName = i => "I" + i;

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using NUnit.Framework;");
            sb.AppendLine("[TestFixture]");

            sb.AppendLine("public class Test");
            sb.AppendLine("{");

            sb.AppendLine("[Test]");
            sb.AppendLine("public void bling()");
            sb.AppendLine("{");
            sb.AppendLine("Class1 class1 = new Class1();");

            for (int i = 0; i < iterations; i++)
            {
                sb.AppendLine(getInterfaceName(i) + " int" + i + " = class1;");
                sb.AppendLine("int" + i + ".Bling();");
            }

            sb.AppendLine("}");

            for (int i = 0; i < iterations; i++)
            {
                sb.AppendLine("public interface " + getInterfaceName(i) + " { void Bling(); }");
            }

            sb.Append("public class Class1 : " + getInterfaceName(0));

            for (int i = 1; i < iterations; i++)
            {
                sb.Append(", " + getInterfaceName(i));
            }

            sb.Append("{ public void Bling(){} }");
            sb.AppendLine("}");

            File.WriteAllText(@"C:\Temp\tmp.cs", sb.ToString());
    */

/*
            Func<int, string> projection = x => "Value=" + x;
            int[] values = { 3, 7, 10 };
            var strings = values.Select(projection);

            foreach (string s in strings)
            {
                Console.WriteLine(s);
            }
*/

            exitCode = 0;
        }


        static int maxSubArraySum(int[] a)
        {
            int size = a.Length;
            int max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here = max_ending_here + a[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }

        static int maxSubArraySum1(int[] a)
        {
            int size = a.Length;

            int max_so_far = int.MinValue;
            int max_ending_here = 0;
            int x1 = 0, x2 = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here = max_ending_here + a[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }


        static (int X1, int X2, int S)  maxSubArraySum2(int[] a)
        {
            int max_ending_here = a[0];
            int max_so_far = a[0];
            int x1 = 0, x2 = 0;

            for ( int i=1; i < a.Length; i++ )
            {
                x1 = (a[i] > max_ending_here) ? i : x1;
                max_ending_here = Math.Max(a[i], max_ending_here + a[i]);

                x2 = (max_ending_here > max_so_far) ? i : x2;
                max_so_far = Math.Max(max_so_far, max_ending_here);
            }
            return (x1, x2, max_so_far);
        }

/*
        def max_subarray(A):
2     max_ending_here = max_so_far = A[0]
3     for x in A[1:]:
4         max_ending_here = max(x, max_ending_here + x)
5         max_so_far = max(max_so_far, max_ending_here)
6     return max_so_far
*/
    }
}
