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

public class NumIslandsIterativeDfsImplementation : INumIslandsImplementation
{
    public int NumIslands(char[][] grid)
    {
        var numberOfIslands = 0;

        var stack = new Stack<(int i, int j)>();
        for (var i = 0; i < grid.Length; i++)
        for (var j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] == '1')
            {
                numberOfIslands++;
                stack.Push((i, j));
            }

            while (stack.Count > 0)
            {
                var (poppedI, poppedJ) = stack.Pop();
                TryPush(poppedI, poppedJ + 1);
                TryPush(poppedI + 1, poppedJ);
                TryPush(poppedI, poppedJ - 1);
                TryPush(poppedI - 1, poppedJ);
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
        for (var i = 0; i < grid.Length; i++)
        for (var j = 0; j < grid[i].Length; j++)
        {
            if (grid[i][j] == '1')
            {
                numberOfIslands++;
                queue.Enqueue((i, j));
            }

            while (queue.Count > 0)
            {
                var (dequeuedI, dequeuedJ) = queue.Dequeue();
                TryEnqueue(dequeuedI, dequeuedJ + 1);
                TryEnqueue(dequeuedI + 1, dequeuedJ);
                TryEnqueue(dequeuedI, dequeuedJ - 1);
                TryEnqueue(dequeuedI - 1, dequeuedJ);
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