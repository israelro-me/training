using Challenges;
using Shouldly;
using Xunit;

namespace Tests;

public class TwoNumbersShouldSumToTarget
{
    public static TheoryData<int[], int, int[]> GetTwoSumCases()
    {
        return new TheoryData<int[], int, int[]>
        {
            { [2, 7, 11, 15], 9, [0, 1] },
            { [3, 2, 4], 6, [1, 2] },
            { [3, 3], 6, [0, 1] }
        };
    }

    [Theory]
    [MemberData(nameof(GetTwoSumCases))]
    public void ReturnsIndicesOfTwoNumbersThatAddToTarget(int[] input, int target, int[] expected)
    {
        var result = TwoSumSolver.TwoSum(input, target);
        result.ShouldBe(expected, true);
    }
}