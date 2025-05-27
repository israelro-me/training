namespace Challenges;

public interface INumIslandsImplementation
{
    int NumIslands(char[][] grid);
}

public class NumIslandsRecursiveDfsImplementation : INumIslandsImplementation
{
    public int NumIslands(char[][] grid)
    {
        var numberOfIslands = 0;
        for (var r = 0; r < grid.Length; r++)
        for (var c = 0; c < grid[r].Length; c++)
        {
            if (grid[r][c] != '1') continue;
            if (Dfs(r, c))
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

public class NumIslandsIterativeDfsImplementation : INumIslandsImplementation
{
    public int NumIslands(char[][] grid)
    {
        var numberOfIslands = 0;

        var stack = new Stack<(int i, int j)>();
        for (var r = 0; r < grid.Length; r++)
        for (var c = 0; c < grid[r].Length; c++)
        {
            if (grid[r][c] == '1')
            {
                numberOfIslands++;
                stack.Push((r, c));
            }

            while (stack.Count > 0)
            {
                var (i, j) = stack.Pop();
                TryPush(i, j + 1);
                TryPush(i + 1, j);
                TryPush(i, j - 1);
                TryPush(i - 1, j);
            }
        }

        return numberOfIslands;

        void TryPush(int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length) return;
            if (grid[i][j] != '1') return;
            grid[i][j] = '*';
            stack.Push((i, j));
        }
    }
}

public class NumIslandsIterativeBfsImplementation : INumIslandsImplementation
{
    public int NumIslands(char[][] grid)
    {
        var numberOfIslands = 0;
        var queue = new Queue<(int i, int j)>();
        for (var r = 0; r < grid.Length; r++)
        for (var c = 0; c < grid[r].Length; c++)
        {
            if (grid[r][c] == '1')
            {
                numberOfIslands++;
                queue.Enqueue((r, c));
            }

            while (queue.Count > 0)
            {
                var (i, j) = queue.Dequeue();
                TryEnqueue(i, j + 1);
                TryEnqueue(i + 1, j);
                TryEnqueue(i, j - 1);
                TryEnqueue(i - 1, j);
            }
        }

        return numberOfIslands;

        void TryEnqueue(int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length) return;
            if (grid[i][j] != '1') return;
            grid[i][j] = '*';
            queue.Enqueue((i, j));
        }
    }
}