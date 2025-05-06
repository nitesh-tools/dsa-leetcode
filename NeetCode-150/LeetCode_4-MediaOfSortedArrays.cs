namespace dsa_leetcode.NeetCode_150;

/// <summary>
/// https://leetcode.com/problems/median-of-two-sorted-arrays
/// </summary>
internal class LeetCode_4_MediaOfSortedArrays
{
    /// <summary>
    /// Approach: Create a third bigArray using space O(m+n).
    /// Merge both original arrays to new array using two pointer's approach, Complexity: O(m+n)
    /// Find the median from new array.
    /// </summary>
    /// <param name="nums1"></param>
    /// <param name="nums2"></param>
    /// <returns>Median</returns>
    public double FindMedian(int[] nums1, int[] nums2)
    {
        int first = 0, second = 0;
        int totalLength = nums1.Length + nums2.Length;
        List<int> nums = new List<int>();

        while (first < nums1.Length && second < nums2.Length)
        {
            if (nums1[first] <= nums2[second]) nums.Add(nums1[first++]);
            else nums.Add(nums2[second++]);
        }

        while (first < nums1.Length) nums.Add(nums1[first++]);
        while (second < nums2.Length) nums.Add(nums2[second++]);

        int half = totalLength / 2;

        if (totalLength % 2 != 0) return nums[half];
        else
        {
            double sum = nums[half] + nums[half - 1];
            return sum / 2;
        }
    }

    public static void Run()
    {
        var obj = new LeetCode_4_MediaOfSortedArrays();
        var result = obj.FindMedian([1, 2], [3, 4]);

        Console.WriteLine($"Median of arrays is: {result}");
    }
}
