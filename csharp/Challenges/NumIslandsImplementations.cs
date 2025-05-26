namespace Challenges;

public static class NumIslandsImplementations
{
    public static int NumIslands(char[][] grid)
    {
        var numberOfIslands = 0;
        for (var i = 0; i < grid.Length; i++)
        for (var j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] != '1') continue;
            if (Dfs(i, j))
                numberOfIslands++;
        }

        return numberOfIslands;

        bool Dfs(int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length)
                return false;

            if (grid[i][j] != '1')
                return false;

            grid[i][j] = '*';
            Dfs(i, j + 1);
            Dfs(i + 1, j);
            Dfs(i, j - 1);
            Dfs(i - 1, j);

            return true;
        }
    }
}