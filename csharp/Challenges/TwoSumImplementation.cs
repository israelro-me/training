namespace Challenges;

/// <summary>
///     Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to
///     target.
///     Source: https://leetcode.com/problems/two-sum
/// </summary>
public static class TwoSumImplementation
{
    public static int[] TwoSum(int[] nums, int target)
    {
        var seen = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (seen.TryGetValue(target - nums[i], out var seenIndex))
                return [seenIndex, i];

            seen[nums[i]] = i;
        }

        throw new ArgumentException("Input should have had exactly one solution.");
    }
}