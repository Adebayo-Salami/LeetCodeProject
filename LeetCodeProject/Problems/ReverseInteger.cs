using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.Problems
{
    public static class ReverseInteger
    {
        public static void Run()
        {
            Console.WriteLine("Reverse Integer");

            Console.WriteLine("Result for 123: " + OptReverse(123));
            Console.WriteLine("Result for -123: " + OptReverse(-123));
            Console.WriteLine("Result for 120: " + OptReverse(120));
        }

        static int Reverse(int x)
        {
            int ans = 0;

            try
            {
                if (x == 0)
                    return ans;

                string xStr = Math.Abs(x).ToString();
                StringBuilder stringBuilder = new();
                for(int i = xStr.Length - 1; i >= 0; i--)
                {
                    stringBuilder.Append(xStr[i]);
                }
                xStr = stringBuilder.ToString();
                ans = Convert.ToInt32(xStr);
                double test = Convert.ToDouble(xStr);
                if (ans != test)
                    ans = 0;
                else if (x < 0)
                    ans = -ans;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ans;
        }

        static int OptReverse(int x)
        {
            int reversed = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;

                // Check for overflow conditions
                if (reversed > int.MaxValue / 10 || (reversed == int.MaxValue / 10 && pop > 7))
                    return 0;
                if (reversed < int.MinValue / 10 || (reversed == int.MinValue / 10 && pop < -8))
                    return 0;

                reversed = reversed * 10 + pop;
            }
            return reversed;
        }
    }
}
