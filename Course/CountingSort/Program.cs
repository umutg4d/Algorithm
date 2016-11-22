using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountingSort
{
    class Program
    {
        void CountSort()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arrn = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            int[] c = new int[6];
            for (int i = 0; i < n; i++)
            {
                c[arrn[i]]++;
            }
            for (int j = 1; j < c.Length; j++)
            {
                c[j] = c[j] + c[j - 1];//j'ye eşit veya küçük kaç tane değer olduğu c[j]'de gösterilecek.
            }
            int[] b = new int[n];
            for (int k = n - 1; k >= 0; k--)
            {
                b[c[arrn[k]] - 1] = arrn[k];
                c[arrn[k]]--;
            }
            foreach (var item in b)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arrn = new int[n];
            string[] arrs = new string[n];
            for (int i = 0; i < n; i++)
            {
                string[] t=Console.ReadLine().Split();
                arrn[i] = Convert.ToInt32(t[0]);
                if (i<n/2)
                {
                    arrs[i] = "-";
                }else arrs[i] = t[1];
            }
            int[] c = new int[100];
            for (int i = 0; i < n; i++)
            {
                c[arrn[i]]++;
            }
            for (int j = 1; j < c.Length; j++)
            {
                c[j] = c[j] + c[j - 1];//j'ye eşit veya küçük kaç tane değer olduğu c[j]'de gösterilecek.
            }
            string[] b = new string[n];
            for (int k = n - 1; k >= 0; k--)
            {
                b[c[arrn[k]] - 1] = arrs[k];
                c[arrn[k]]--;
            }
            foreach (var item in b)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();
        }
    }
}
