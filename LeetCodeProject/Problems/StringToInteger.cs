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

            Console.WriteLine("Result for 21474836460: " + MyAtoi2("-91283472332"));
            Console.WriteLine("Result for 21474836460: " + MyAtoi2("21474836460"));
            Console.WriteLine("Result for 21474836460: " + MyAtoi2("+-12"));
            Console.WriteLine("Result for 21474836460: " + MyAtoi2("-91283472332"));
            Console.WriteLine("Result for 21474836460: " + MyAtoi("21474836460"));
            Console.WriteLine("Result for 42: " + MyAtoi("42"));
            Console.WriteLine("Result for -042: " + MyAtoi("-042"));
            Console.WriteLine("Result for 1337c0d3: " + MyAtoi("1337c0d3"));
            Console.WriteLine("Result for 0-1: " + MyAtoi("0-1"));
            Console.WriteLine("Result for words and 987: " + MyAtoi("words and 987"));
        }

        static int AIMyAtoi(string s)
        {
            // Remove leading whitespaces
            s = s.Trim();

            // Check if the string is empty
            if (string.IsNullOrEmpty(s))
                return 0;

            // Initialize variables
            int i = 0;
            int sign = 1; // Default positive sign
            long result = 0; // Use long to handle overflow

            // Check for sign
            if (s[i] == '-' || s[i] == '+')
            {
                sign = s[i] == '-' ? -1 : 1;
                i++;
            }

            // Read digits
            while (i < s.Length && char.IsDigit(s[i]))
            {
                result = result * 10 + (s[i] - '0');

                // Check for overflow
                if (result * sign > int.MaxValue)
                    return int.MaxValue;
                if (result * sign < int.MinValue)
                    return int.MinValue;

                i++;
            }

            return (int)(result * sign);
        }

        static int MyAtoi2(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
                return 0;

            char[] acceptedChars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] signChars = { '-', '+' };
            var stringArray = s.ToCharArray();
            var stringBuilder = new StringBuilder();
            bool isStarted = false;
            bool isPositive = true;
            for(int i = 0; i < stringArray.Length; i++)
            {
                char c = stringArray[i];
                if (!isStarted)
                {
                    if (c == ' ')
                        continue;

                    if (signChars.Contains(c))
                    {
                        if (c == '-')
                            isPositive = false;
                        isStarted = true;
                    }
                    else if (acceptedChars.Contains(c))
                    {
                        isStarted = true;
                        stringBuilder.Append(c);
                    }
                    else
                        break;
                }
                else
                {
                    if (signChars.Contains(c))
                        break;

                    if (acceptedChars.Contains(c))
                        stringBuilder.Append(c);
                    else
                        break;
                }
            }

            if (stringBuilder.Length == 0)
                return 0;

            int result = 0;
            var formattedString = stringBuilder.ToString();
            if (int.TryParse(formattedString, out result))
            {
                if (!isPositive)
                    return -result;
            }
            else if (isPositive)
                result = int.MaxValue;
            else
                result = int.MinValue;

            return result;
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
