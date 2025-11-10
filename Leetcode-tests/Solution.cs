public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int count = 0;
        var bla = nums.Distinct().OrderBy(x => x);
        foreach (var n in bla)
        {
            nums[count] = n;
            count++;
        }
        return bla.Count();
    }
    public int MaxProfit(int[] prices)
    {
        int profit = 0;
        for (int i = 0; i < prices.Length - 1; i++)
        {
            var diff = prices[i + 1] - prices[i];
            if (diff > 0) profit += diff;
        }
        return profit;
    }
    public void Rotate(int[] nums, int k)
    {
        var n = nums.Length;
        if (n < 2) return;
        if (k <= 0) return;
        k = k % n;

        var k0 = new int[k];

        for (int i = 0; i < k; i++)
        {
            k0[i] = nums[n - k + i];
        }

        for (int i = n - 1; i >= k; i--)
        {
            nums[i] = nums[i - k];
        }

        for (int i = 0; i < k; i++)
        {
            nums[i] = k0[i];
        }
    }
    public bool ContainsDuplicate(int[] nums)
    {
        return nums.Length > nums.Distinct().Count();
    }

    public int SingleNumber(int[] nums)
    {
        return nums.GroupBy(x => x)
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .FirstOrDefault(x => x.Count == 1).Value;
    }

    public int[] Intersect(int[] nums1, int[] nums2)
    {
        var intersect = new List<int>();
        var sorted1 = nums1.OrderBy(x => x).ToArray();
        var sorted2 = nums2.OrderBy(x => x).ToArray();
        var k = 0;
        foreach (var n in sorted1)
        {
            for (var i = k; i < sorted2.Length; i++)
            {
                var m = sorted2[i];
                if (n == m)
                {
                    intersect.Add(n);
                    k = i + 1;
                    break;
                }
            }
        }
        return intersect.ToArray();
    }

    public int[] PlusOne(int[] digits)
    {
        var n = digits.Length;

        var list = digits.ToList();

        for (int i = n - 1; i >= 0; i--)
        {
            var d = list[i];
            if (d < 9)
            {
                list[i] = d + 1;
                break;
            }
            else
            {
                list[i] = 0;
            }
        }

        if (list[0] == 0)
        {
            list.Insert(0, 1);
        }

        return [.. list];
    }

    public void MoveZeroes(int[] nums)
    {
        int zeroCount = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                zeroCount++;
                if (i >= nums.Length - zeroCount + 1) break;
                nums[i] = nums[i + 1];
                nums[i + 1] = 0;
            }
        }
    }
}