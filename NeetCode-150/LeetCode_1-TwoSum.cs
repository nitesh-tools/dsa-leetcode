namespace dsa_leetcode.NeetCode_150;

/// <summary>
/// https://leetcode.com/problems/two-sum
/// </summary>
internal class LeetCode_1_TwoSum
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (dictionary.ContainsKey(target - nums[i]))
            {
                return [i, dictionary[target - nums[i]]];
            }
            else
            {
                if (!dictionary.ContainsKey(nums[i])) dictionary.Add(nums[i], i);
            }
        }

        return [];
    }

    public static void Run()
    {
        var obj = new LeetCode_1_TwoSum();
        var result = obj.TwoSum([2, 7, 11, 15], 9);

        if (result.Length > 1)
            Console.WriteLine($"Result is: [{result[0]}, {result[1]}]");
        else
            Console.WriteLine($"Result is: []");
    }
}
