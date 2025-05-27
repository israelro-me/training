import queue
from abc import ABC, abstractmethod
from enum import nonmember
from typing import List
from collections import deque


class NumIslandsImplementation(ABC):
    """
    Base class for all NumIslands implementations.
    Implementations must override `num_islands`.
    """

    @abstractmethod
    def num_islands(self, grid: List[List[str]]) -> int:
        """
        Count the number of islands in a 2D grid of '1's (land) and '0's (water).
        :param grid: a rectangular List of List of '1'/'0' strings
        :return: integer count of islands
        """
        raise NotImplementedError


class RecursiveDfsImplementation(NumIslandsImplementation):
    """
    Recursive DFS-based implementation of NumIslands.
    """

    def num_islands(self, grid: List[List[str]]) -> int:
        def dfs(i: int, j: int) -> bool:
            if i < 0 or i >= len(grid) or j < 0 or j >= len(grid[i]):
                return False

            if grid[i][j] != '1':
                return False

            grid[i][j] = '*'
            dfs(i, j + 1)
            dfs(i + 1, j)
            dfs(i, j - 1)
            dfs(i - 1, j)

            return True

        number_of_islands = 0

        for r, row in enumerate(grid):
            for c, cell in enumerate(row):
                if cell != '1':
                    continue
                if dfs(r, c):
                    number_of_islands += 1

        return number_of_islands


class IterativeDfsImplementation(NumIslandsImplementation):
    """
    Iterative DFS (using an explicit stack) implementation of NumIslands.
    """

    def num_islands(self, grid: List[List[str]]) -> int:
        def try_append(i: int, j: int) -> None:
            if i < 0 or i >= len(grid) or j < 0 or j >= len(grid[i]):
                return None
            if grid[i][j] != '1':
                return None
            grid[i][j] = '*'
            stack.append((i, j))

            return None

        number_of_islands = 0
        stack = deque()
        for i, row in enumerate(grid):
            for j, cell in enumerate(row):
                if cell == '1':
                    number_of_islands += 1
                    stack.append((i, j))

                while stack:
                    i, j = stack.pop()
                    try_append(i, j)
                    try_append(i, j + 1)
                    try_append(i + 1, j)
                    try_append(i, j - 1)
                    try_append(i - 1, j)

        return number_of_islands


class IterativeBfsImplementation(NumIslandsImplementation):
    """
    Breadth-first search (using a queue) implementation of NumIslands.
    """

    def num_islands(self, grid: List[List[str]]) -> int:
        def try_append(i: int, j: int) -> None:
            if i < 0 or i >= len(grid) or j < 0 or j >= len(grid[i]):
                return None
            if grid[i][j] != '1':
                return None
            grid[i][j] = '*'
            queue.append((i, j))

            return None

        number_of_islands = 0
        queue = deque()
        for i, row in enumerate(grid):
            for j, cell in enumerate(row):
                if cell == '1':
                    number_of_islands += 1
                    queue.append((i, j))

                    while queue:
                        i, j = queue.popleft()
                        try_append(i, j)
                        try_append(i, j + 1)
                        try_append(i + 1, j)
                        try_append(i, j - 1)
                        try_append(i - 1, j)

        return number_of_islands
