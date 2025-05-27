using Challenges;
using Shouldly;
using Xunit;

namespace Tests;

public abstract class NumIslandsTest<TImplementation> where TImplementation : INumIslandsImplementation, new()
{
    protected readonly INumIslandsImplementation Implementation = new TImplementation();

    public static TheoryData<char[][], int> Cases => new()
    {
        {
            [
                ['1', '1', '1', '1', '0'],
                ['1', '1', '0', '1', '0'],
                ['1', '1', '0', '0', '0'],
                ['0', '0', '0', '0', '0']
            ],
            1
        },
        {
            [
                ['1', '1', '0', '0', '0'],
                ['1', '1', '0', '0', '0'],
                ['0', '0', '1', '0', '0'],
                ['0', '0', '0', '1', '1']
            ],
            3
        },
        {
            [
                ['0', '0', '0'],
                ['0', '0', '0']
            ],
            0
        },
        {
            [
                ['1', '1'],
                ['1', '1']
            ],
            1
        },
        {
            [], 0
        },
        {
            [
                ['0', '0', '0', '0', '0', '0', '0', '1', '0'],
                ['0', '0', '0', '0', '0', '0', '0', '1', '0'],
                ['0', '0', '0', '0', '0', '0', '0', '1', '0'],
                ['0', '1', '1', '1', '1', '1', '0', '1', '0'],
                ['0', '1', '0', '0', '0', '1', '0', '1', '0'],
                ['0', '1', '0', '1', '0', '1', '0', '1', '0'],
                ['0', '1', '0', '0', '0', '1', '0', '1', '0'],
                ['0', '1', '0', '1', '0', '1', '0', '1', '0'],
                ['0', '1', '0', '1', '1', '1', '0', '1', '0'],
                ['0', '1', '0', '0', '0', '0', '0', '1', '0'],
                ['0', '1', '1', '1', '1', '1', '1', '1', '0']
            ],
            2
        }
    };


    [Theory]
    [MemberData(nameof(Cases))]
    public void ReturnsCorrectIslandCount(char[][] grid, int expected)
    {
        var gridCopy = Array.ConvertAll(grid, inner => (char[])inner.Clone());
        Implementation.NumIslands(gridCopy).ShouldBe(expected);
    }
}

public class RecursiveDfsShouldCountNumIslandsCorrectly : NumIslandsTest<NumIslandsRecursiveDfsImplementation>
{
    [Fact]
    public void DoesNotStackOverflowOnDeepOneWideMap()
    {
        var grid = Array.ConvertAll(new char[100][], _ => Enumerable.Repeat('1', 100).ToArray());
        Should.NotThrow(() => Implementation.NumIslands(grid));
    }
}

public class IterativeDfsShouldCountNumIslandsCorrectly : NumIslandsTest<NumIslandsIterativeDfsImplementation>
{
}

public class IterativeBfsShouldCountNumIslandsCorrectly : NumIslandsTest<NumIslandsIterativeBfsImplementation>
{
}