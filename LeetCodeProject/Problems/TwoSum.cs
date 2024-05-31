namespace LeetCodeProject.Problems
{
    public static class TwoSum
    {
        public static void Trial1()
        {
            Console.WriteLine("Running TwoSum Trial1");

            var test1 = LeetCodeTwoSum([2, 7, 11, 15], 9);
            Console.WriteLine("Result: " + String.Join(',', test1));

            var test2 = LeetCodeTwoSum([3, 2, 4], 6);
            Console.WriteLine("Result: " + String.Join(',', test2));

            var test3 = LeetCodeTwoSum([3, 3], 6);
            Console.WriteLine("Result: " + String.Join(',', test3));
        }

        static int[] LeetCodeTwoSum(int[] nums, int target)
        {
            int[] result = [2];
            int size = nums.Length;

            try
            {
                for (int i = 0; i < (size - 1); i++)
                {
                    if (i == size) break;

                    for(int z = i + 1; z < size; z++)
                    {
                        if (z == size) break;

                        if ((nums[i] + nums[z]) == target)
                        {
                            result = [i, z];
                            break;
                        }
                    }
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

            return result;
        }
    }
}
