using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProject.Problems
{
    public static class ZigzagConversion
    {
        public static void Run()
        {
            Console.WriteLine("Zigzag Conversion");

            Console.WriteLine("Result for PAYPALISHIRING: " + Convert("PAYPALISHIRING", 3));
            Console.WriteLine("Result for PAYPALISHIRING: " + Convert("PAYPALISHIRING", 4));
        }

        static string Convert(string s, int numRows)
        {
            var ans = String.Empty;

            try
            {
                if(String.IsNullOrWhiteSpace(s))
                    return s;
                if(numRows <= 0)
                    return s;

                var stringDict = new Dictionary<int, string>();
                var sArray = s.ToCharArray();
                int rowIndex = 0;
                int dropIndex = -1;
                foreach(char c in sArray)
                {
                    bool breakLoop = false;
                    while (!breakLoop)
                    {
                        stringDict.TryAdd(rowIndex, "");
                        if (dropIndex < 0)
                        {
                            stringDict[rowIndex] = stringDict[rowIndex]  + c.ToString();
                            breakLoop = true;
                        }
                        else if (rowIndex == dropIndex)
                        {
                            stringDict[rowIndex] = stringDict[rowIndex] + c.ToString();
                            breakLoop = true;
                        }

                        rowIndex++;
                        if (rowIndex == numRows || rowIndex == (dropIndex + 1))
                        {
                            if (dropIndex == 0)
                            {
                                dropIndex = -1;
                            }
                            else
                            {
                                if (dropIndex < 0)
                                    dropIndex = numRows - 2;
                                else
                                    dropIndex--;

                                rowIndex = 0;
                            }
                        }
                    }
                }

                var buildWord = new StringBuilder();
                foreach(var item in stringDict)
                    buildWord.Append(item.Value.ToString());

                ans = buildWord.ToString();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ans;
        }

        static string OptConvert(string s, int numRows)
        {
            if (numRows == 1)
                return s; // No zigzag pattern for a single row

            var rows = new StringBuilder[numRows];
            for (int i = 0; i < numRows; i++)
                rows[i] = new StringBuilder();

            int currentRow = 0;
            int direction = 1; // 1 for down, -1 for up

            foreach (char c in s)
            {
                rows[currentRow].Append(c);

                if (currentRow == 0)
                    direction = 1;
                else if (currentRow == numRows - 1)
                    direction = -1;

                currentRow += direction;
            }

            var result = new StringBuilder();
            foreach (var row in rows)
                result.Append(row);

            return result.ToString();
        }
    }
}
