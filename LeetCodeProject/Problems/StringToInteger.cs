using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.Problems
{
    public static class StringToInteger
    {
        public static void Run()
        {
            Console.WriteLine("String to Integer");

            Console.WriteLine("Result for 21474836460: " + MyAtoi("21474836460"));
            Console.WriteLine("Result for 42: " + MyAtoi("42"));
            Console.WriteLine("Result for -042: " + MyAtoi("-042"));
            Console.WriteLine("Result for 1337c0d3: " + MyAtoi("1337c0d3"));
            Console.WriteLine("Result for 0-1: " + MyAtoi("0-1"));
            Console.WriteLine("Result for words and 987: " + MyAtoi("words and 987"));
        }

        static int MyAtoi(string s)
        {
            int result = 0;

            try
            {
                if (String.IsNullOrWhiteSpace(s))
                    return result;

                char[] allowedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                var builder = new StringBuilder();
                var sArray = s.ToCharArray();
                bool? isNegative = null;
                bool isFirstRun = true;
                foreach (var c in sArray)
                {
                    if (c == ' ')
                    {
                        isFirstRun = true;
                        continue;
                    }

                    if (c == '-' || c == '+')
                        if (isNegative.HasValue)
                            break;
                        else if (!isFirstRun)
                            break;
                        else
                        {
                            isNegative = (c == '-');
                            continue;
                        }

                    if (c == '0' && isFirstRun)
                    {
                        isFirstRun = false;
                        continue;
                    }
                    isFirstRun = false;

                    if (!allowedChars.Contains(c))
                        break;

                    builder.Append(c);
                }

                var dobFigure = Math.Abs(Convert.ToDouble(builder.ToString()));
                if (builder.Length > 0)
                    result = (int)Convert.ToDouble(builder.ToString());

                result = Math.Abs(result);
                if (isNegative.HasValue && isNegative.Value)
                    result = -result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
    }
}
