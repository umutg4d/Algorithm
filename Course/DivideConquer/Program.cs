using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivideConquer
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[]{ 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int resulti=DCMethod(arr, 0, arr.Length - 1,arr.Length);
        }

        static int DCMethod(int[] arr,int low,int high,int n)
        {
            int midEl = low+((high-low)>>1);
            int a = arr[midEl];
            if ((midEl == 0 || arr[midEl - 1] <= arr[midEl]) && (midEl == n - 1 || arr[midEl + 1] <= arr[midEl]))
                return a;
            else if (a < arr[midEl - 1])
                return DCMethod(arr, low, midEl - 1, n);
            else if (a < arr[midEl + 1])
                return DCMethod(arr, midEl + 1, high, n);
            else return -1;
        }
        }
    }
