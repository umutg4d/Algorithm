using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = new int[] { 38,27,43,3,9,82,10};
            //insertionSort(array);
            //int[] a = { 1, 2, 3, 4, 5 };
            //int[] b = new int[3];
            //Array.Copy(a, 1, b, 0, 3);
            //CountInversionMergeSort(array, 0, array.Length-1);//array,MergeSort ile halledildi.
            long T = Convert.ToInt32(Console.ReadLine());
            List<long> resulti = new List<long>();
            for (int i = 0; i < T; i++)
            {
                long n = Convert.ToInt32(Console.ReadLine());
                long[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int64.Parse);
                resulti.Add(CountInversionMergeSort(arr, 0, n - 1));
            }
            foreach (var item in resulti)
            {
                Console.WriteLine(item);
             
            }
            Console.ReadLine();
        }
        static int InsertionSort(int[] arr)
        {
            int total = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                for (int j = i-1; j >= 0; j--)
                {
                    if (arr[j] > key)
                    {
                        int temp = arr[j];
                        arr[j] = key;
                        arr[j + 1] = temp;
                        total++;
                    }
                    else { break; }
                }
            }return total;
            
        }
        static void insertionSort(int[] ar)
        {
            int key = ar[ar.Length - 1];
            for (int i = ar.Length-2; i >= 0; i--)
            {
                if (ar[i]>key)
                {
                    int temp = ar[i];
                    ar[i + 1] = temp;
                    PrintArray(ar);
                    if (i==0)
                    {
                        ar[i] = key;
                        PrintArray(ar);
                    }
                    
                }
                else if (key>ar[i])
                {
                    ar[i+1] = key;
                    PrintArray(ar);
                    break;
                }
            }

        }
        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        static void MergeSort(int[]arr,int l,int r)
        {
            if (l<r)
            {
                int midEl = l + ((r - l) >> 1);
                MergeSort(arr,l, midEl);
                MergeSort(arr, midEl + 1, r);
                Merge(arr, l,midEl, r);
            }
            
        }
        static long CountInversionMergeSort(long[] arr, long l, long r)
        {
            if (l < r)
            {
                long midEl = l + ((r - l) >> 1);
                long left = CountInversionMergeSort(arr, l, midEl);
                long right = CountInversionMergeSort(arr, midEl + 1, r);
                long merge = CountInversionMerge(arr, l, midEl, r);
                return left + right + merge;
            }
            else return 0;
        }
        static long CountInversionMerge(long[] arr, long l, long middle, long r)
        {
            long n1 = (middle - l) + 1;
            long n2 = r - middle;
            long[] L = new long[n1];
            long[] R = new long[n2];
            long    countInversion = 0;
            for (long i = 0; i < n1; i++)
            {
                L[i] = arr[l + i];
            }
            for (long i = 0; i < n2; i++)
            {
                R[i] = arr[middle + 1 + i];
            }
            //L ve R için karıştırma yapılmalı.
            long ind1 = 0, ind2 = 0;
            for (long i = 0; i < n1 + n2; i++)
            {
                if (L[ind1] > R[ind2])
                {
                    arr[l + i] = R[ind2];
                    countInversion += (n1- ind1);
                    ind2++;
                    if (ind2 == n2)
                    {
                        //Kalan L elemanları A içinde kalan yere geçirilmeli.
                        Array.Copy(L, ind1, arr, i + l + 1, n1 - ind1);
                        break;
                    }

                }
                else
                {
                    arr[l + i] = L[ind1];
                    ind1++;

                    if (ind1 == n1)
                    {
                        //Kalan R elemanları A içinde yerleştirilmeliler.
                        Array.Copy(R, ind2, arr, i + l + 1, n2 - ind2);
                        break;
                    }

                }
            }
            return countInversion;
        }
        static void Merge(int[]arr,int l,int middle,int r)
        {
            int n1 = (middle-l)+1 ;
            int n2 = r - middle;
            int[] L = new int[n1];
            int[] R = new int[n2];
            
            for (int i = 0; i < n1; i++)
            {
                L[i] = arr[l + i];
            }
            for (int i = 0; i < n2; i++)
            {
                R[i] = arr[middle + 1 + i];
            }
            //L ve R için karıştırma yapılmalı.
            int ind1 = 0, ind2 = 0;
            for (int i = 0; i < n1+n2; i++)
            {
                if (L[ind1]>R[ind2])
                {
                    arr[l + i]=R[ind2];
                    ind2++;
                    if (ind2 == n2)
                    {
                        //Kalan L elemanları A içinde kalan yere geçirilmeli.
                        Array.Copy(L, ind1, arr, i+l+1, n1-ind1);
                        break;
                    }
                        
                }else
                {
                    arr[l + i] = L[ind1];
                    ind1++;
                    if (ind1 == n1)
                    {
                        //Kalan R elemanları A içinde yerleştirilmeliler.
                        Array.Copy(R, ind2, arr, i+l+1, n2-ind2);
                        break;
                    }
                        
                }
            }
            

        }
    }
}
