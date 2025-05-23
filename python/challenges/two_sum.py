def two_sum(nums: list[int], target: int) -> list[int]:
    """
    Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to
    target.

    Source: https://leetcode.com/problems/two-sum
    """

    seen = {}
    for i, num in enumerate(nums):
        complement = target - num
        if complement in seen:
            return [seen[complement], i]

        seen[num] = i

    raise ValueError("Input should have had exactly one solution.")
