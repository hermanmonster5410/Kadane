using System;
using System.Collections;
using System.Collections.Generic;

namespace Longest_Dictionary_Word_Matching_Anagrams
{
    class Program
    {
//      static string[] s = {"A", "B", "C", "D", "E", "F", "G", "H" };
        static string[] s = { "A", "B", "C", "D"};

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            QuickPerm(s);
            Console.ReadLine();
        }

        public static void QuickPerm(string[] a)
        {
            int size = a.Length;
            int[] p = new int[size + 1];

            for (int x = 0; x <= size; x++)
                p[x] = x;

            int i = 1;

            int j;
            string tmp;

            int permNum = 1;
            PrintArray(a);

            while (i < size)
            {
                p[i]--;
                j = (i % 2 == 1) ? p[i] : 0;
                tmp = a[j];
                a[j] = a[i];
                a[i] = tmp;

                PrintArray(a);
                permNum++;

                i = 1;
                while (p[i] == 0)
                {
                    p[i++] = 1;
                }
            }
            Console.WriteLine("\n\nTotal permutations: " + permNum );
        }

        static void PrintArray(string[] a)
        {
            foreach (string s in a)
                Console.Write(s + "  ");
            Console.WriteLine();
        }
        
    }


    public static class Permutations<T>
    {
        static List<T[]> Permutate(T[] a)
        {
            if (a.Length == 1)
            {
                List<T[]> l = new List<T[]>();
                l.Add(a);
                return l;
            }
            else if (a.Length == 2)
            {
                T[] a2 = { a[2], a[1] };
                List<T[]> l = new List<T[]>();
                l.Add(a);
                l.Add(a2);
                return l;
            }
            else
            {

            }
            return null;
        }
    }


    /*
            public static IEnumerable<IEnumerable<T>> QuickPerm<T>(this IEnumerable<T>, IEnumerable<T> set)
            { 
                int N = set.Count();
                int[] a = new int[N];
                int[] p = new int[N];

                var yieldRet = new T[N];

                List<T> list = new List<T>(set);

                int i, j, tmp; // Upper Index i; Lower Index j

                for (i = 0; i < N; i++)
                {
                    // initialize arrays; a[N] can be any type
                    a[i] = i + 1; // a[i] value is not revealed and can be arbitrary
                    p[i] = 0; // p[i] == i controls iteration and index boundaries for i
                }

                yield return list;

                //display(a, 0, 0);   // remove comment to display array a[]
                i = 1; // setup first swap points to be 1 and 0 respectively (i & j)
                while (i < N)
                {
                    if (p[i] < i)
                    {
                        j = i % 2 * p[i]; // IF i is odd then j = p[i] otherwise j = 0
                        tmp = a[j]; // swap(a[j], a[i])
                        a[j] = a[i];
                        a[i] = tmp;

                        //MAIN!

                        for (int x = 0; x < N; x++)
                        {
                            yieldRet[x] = list[a[x] - 1];
                        }
                        yield return yieldRet;
                        //display(a, j, i); // remove comment to display target array a[]

                        // MAIN!

                        p[i]++; // increase index "weight" for i by one
                        i = 1; // reset index i to 1 (assumed)
                    }
                    else
                    {
                        // otherwise p[i] == i
                        p[i] = 0; // reset p[i] to zero
                        i++; // set new index value for i (increase by one)
                    } // if (p[i] < i)
                } // while(i < N)
            }
    */


/*
    let a[] represent an arbitrary list of objects to permute
   let N equal the length of a[]
   create an integer array p[] of size N+1 to control the iteration
   initialize p[0] to 0, p[1] to 1, p[2] to 2, ..., p[N] to N
   initialize index variable i to 1
   while (i<N) do {
      decrement p[i] by 1
      if i is odd, then let j = p[i] otherwise let j = 0
      swap(a[j], a[i])
      let i = 1
      while (p[i] is equal to 0) do {
         let p[i] = i
         increment i by 1
      } // end while (p[i] is equal to 0)
   } // en
*/

}


