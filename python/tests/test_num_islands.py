import importlib
import inspect
import copy
import pytest

# 1) Dynamically load the implementations module
impl_mod = importlib.import_module("challenges.num_islands")

# 2) Reference the abstract base class
BaseImpl = getattr(impl_mod, "NumIslandsImplementation")

# 3) Discover all concrete implementations
IMPLEMENTATIONS = [
    cls()
    for _, cls in inspect.getmembers(impl_mod, inspect.isclass)
    if issubclass(cls, BaseImpl)
       and cls is not BaseImpl
       and cls.__module__ == impl_mod.__name__
       and not inspect.isabstract(cls)
]

# 4) Common test cases: (grid, expected_count)
CASES = [
    ([["1"]], 1),
    ([["0","0"], ["0","0"]], 0),
    ([["1","1"], ["1","0"]], 1),
    ([["1","0"], ["0","1"]], 2),
    (
        [
            ["1","1","0","0","0"],
            ["1","1","0","0","0"],
            ["0","0","1","0","0"],
            ["0","0","0","1","1"],
        ],
        3
    ),
    (
        [
            ["0","0","0","0","0","0","0","1","0"],
            ["0","0","0","0","0","0","0","1","0"],
            ["0","0","0","0","0","0","0","1","0"],
            ["0","1","1","1","1","1","0","1","0"],
            ["0","1","0","0","0","1","0","1","0"],
            ["0","1","0","1","0","1","0","1","0"],
            ["0","1","0","0","0","1","0","1","0"],
            ["0","1","0","1","0","1","0","1","0"],
            ["0","1","0","1","1","1","0","1","0"],
            ["0","1","0","0","0","0","0","1","0"],
            ["0","1","1","1","1","1","1","1","0"],
        ],
        2
    ),
]

@pytest.mark.parametrize("implementation", IMPLEMENTATIONS, ids=lambda impl: impl.__class__.__name__)
@pytest.mark.parametrize("grid, expected", CASES)
def test_num_islands(implementation, grid, expected):
    # deep-copy since implementations mutate the grid in-place
    grid_copy = [row[:] for row in grid]
    assert implementation.num_islands(grid_copy) == expected
