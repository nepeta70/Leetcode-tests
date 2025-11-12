public class EasyArray
{
    public int RemoveDuplicates(int[] nums)
    {
        int count = 0;
        var distinct = nums.Distinct().OrderBy(x => x);
        foreach (var n in distinct)
        {
            nums[count] = n;
            count++;
        }
        return count;
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
    public bool ContainsDuplicate(int[] nums) => nums.Length > nums.Distinct().Count();

    public int SingleNumber(int[] nums) => nums.GroupBy(x => x)
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .FirstOrDefault(x => x.Count == 1).Value;

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
        var list = nums.Where(x => x != 0).ToList();
        for (int i = 0; i < list.Count; i++)
        {
            nums[i] = list[i];
        }
        for (int i = list.Count; i < nums.Length; i++)
        {
            nums[i] = 0;
        }
    }

    public int[] TwoSum(int[] nums, int target)
    {

        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target) return new int[] { i, j };
            }
        }
        return null;
    }

    public bool IsValidSudoku(char[][] board)
    {
        for (int i = 0; i < board.Length; i++)
        {
            var column = new List<char>();
            var row = new List<char>();
            var square = new List<char>();
            var q0 = 3 * (i % 3);
            var r0 = 3 * (i / 3);
            for (int j = 0; j < board.Length; j++)
            {
                var rowCell = board[i][j];
                if (rowCell != '.')
                {
                    if (row.Contains(rowCell)) return false;
                    row.Add(rowCell);
                }

                var colCell = board[j][i];
                if (colCell != '.')
                {
                    if (column.Contains(colCell)) return false;
                    column.Add(colCell);
                }
                var iq = q0 + j / 3;
                var jq = r0 + j % 3;
                var squareCell = board[iq][jq];
                if (squareCell != '.')
                {
                    if (square.Contains(squareCell)) return false;
                    square.Add(squareCell);
                }
            }
        }
        return true;
    }

    public void Rotate(int[][] matrix)
    {
        var d = matrix.Length;
        int h = d / 2;
        var y0 = 0;
        var d0 = d - 1;
        var d1 = d0;

        for (int x = 0; x < h; x++)
        {
            for (int y = y0; y < d1; y++)
            {
                var d2 = d1;
                for (int i = 0; i < d2; i++)
                {
                    var rowIndex0 = y;
                    var colIndex0 = y + i;
                    var previousCell = matrix[rowIndex0][colIndex0];

                    // new column index = initial row index
                    // new row index = d0 - initial column index
                    var colIndex1 = d1 - rowIndex0;
                    var nextCell = matrix[colIndex0][colIndex1];
                     // Top to right
                    matrix[colIndex0][colIndex1] = previousCell;

                    // new row index = previous column index
                    // new column index = d0 - previous row index
                    var colIndex2 = d1 - colIndex0;

                    previousCell = matrix[colIndex1][colIndex2];
                    // Right to bottom
                    matrix[colIndex1][colIndex2] = nextCell;

                    // new column index = previous row index
                    // new row index = d0 - previous column index
                    var colIndex3 = d1 - colIndex1;                    
                    nextCell = matrix[colIndex2][colIndex3];

                    // Bottom to left
                    matrix[colIndex2][colIndex3] = previousCell;
                    // new row index = previous column index = initial row index
                    // new column index = d0 - previous row index = initial column index
                    // Left to top
                    matrix[rowIndex0][colIndex0] = nextCell;
                }

                y0++;
                d1--;
            }
        }
        //var d = matrix.Length;
        //var h = (int)Math.Floor((decimal)d / 3);
        //var y0 = 0;
        //var d0 = d - 1;
        //var d1 = d0;

        //for (int x = 0; x < h; x++)
        //{
        //    for (int y = y0; y < d1; y++)
        //    {
        //        var r0 = y;
        //        var c0 = y;

        //        var cell0 = matrix[r0][c0];
        //        var c1 = d0 - r0;
        //        var cell1 = matrix[r0][c1];
        //        matrix[r0][c1] = cell0;
        //        cell0 = matrix[c1][c1];
        //        matrix[c1][c1] = cell1;
        //        cell1 = matrix[c1][c0];
        //        matrix[c1][c0] = cell0;
        //        matrix[r0][c0] = cell1;

        //        y0++;
        //        d1--;
        //    }
        //}

    }
}