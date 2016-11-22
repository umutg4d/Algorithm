using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5678;
            int b = 1234;
            KaratsubaMult(a, b);
            
        }
        static int KaratsubaMult(int x,int y)
        {
            int firstDigit=(int)Math.Floor(Math.Log10(x) + 1);
            int secondDigit= (int)Math.Floor(Math.Log10(y) + 1);
            if (firstDigit == 1||secondDigit==1)
            {
                return x * y;
            }
            int a = x / ((int)Math.Pow(10, firstDigit/2));
            int b = x % ((int)Math.Pow(10, firstDigit/2));
            int c = y / ((int)Math.Pow(10, secondDigit/2));
            int d = y % ((int)Math.Pow(10, secondDigit/2));
            int firstRes=KaratsubaMult(a, c);
            int secRes = KaratsubaMult(b, d);
            int thirdRes = KaratsubaMult(a + b, c + d)-(firstRes+secRes);
            return 0;
        }
    }
}
