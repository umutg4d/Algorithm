using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryIndexedTree
{

    public class NumArray
    {
        int[] nums;
        int[] BIT;
        int n;

        public NumArray(int[] nums)
        {
            this.nums = nums;

            n = nums.Length;
            BIT = new int[n + 1];
            for (int i = 0; i < n; i++)
                init(i, nums[i]);
        }

        public void init(int i, int val)
        {
            i++;
            while (i <= n)
            {
                BIT[i] += val;
                i += (i & -i);
            }
        }

        void update(int i, int val)
        {
            int diff = val - nums[i];
            nums[i] = val;
            init(i, diff);
        }

        public int getSum(int i)
        {
            int sum = 0;
            i++;
            while (i > 0)
            {
                sum += BIT[i];
                i -= (i & -i);//Parenta gitmek için yapılan binary işlem
            }
            return sum;
        }

        public int sumRange(int i, int j)
        {
            return getSum(j) - getSum(i - 1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
