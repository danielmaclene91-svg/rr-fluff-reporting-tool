// INTENTIONALLY flawed C# fixture for the Plokr Code Quality audit.
// Not real code — every method deliberately encodes a clean-code or
// algorithmic-efficiency smell for the AI quality engine to detect.
using System.Collections.Generic;

namespace Example.Messy
{
    public class Messy
    {
        // O(n^2): List.Contains (a linear scan) inside a loop. Use a HashSet for O(1).
        public int ReconcileOrders(List<int[]> orders, List<int> paidIds)
        {
            int matched = 0;
            foreach (var order in orders)
            {
                for (int i = 0; i < paidIds.Count; i++)
                {
                    if (paidIds.Contains(order[0]))
                    {
                        matched++;
                    }
                }
            }
            return matched;
        }

        // O(n^3): three nested loops.
        public long CrossJoin(int[] a, int[] b, int[] c)
        {
            long total = 0;
            foreach (var x in a)
            {
                foreach (var y in b)
                {
                    foreach (var z in c)
                    {
                        total += (long)x * y * z;
                    }
                }
            }
            return total;
        }

        // Control flow nested five levels deep — flatten with early returns.
        public int DeeplyNested(List<string[]> items)
        {
            int count = 0;
            foreach (var it in items)
            {
                if (it.Length > 0)
                {
                    foreach (var tag in it)
                    {
                        if (!string.IsNullOrEmpty(tag))
                        {
                            if (tag == "vip")
                            {
                                if (it.Length > 2)
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
            }
            return count;
        }

        // Long, multi-responsibility method; duplicated magic-number thresholds.
        public int ProcessEverything(List<int[]> orders)
        {
            int totalRevenue = 0;
            int vip = 0;

            foreach (var o in orders)
            {
                totalRevenue += o[1];
                if (o[1] < 0) totalRevenue -= o[1];
            }

            foreach (var o in orders)
            {
                foreach (var other in orders)
                {
                    if (o[0] == other[0]) vip++;
                }
            }

            foreach (var o in orders)
            {
                if (o[1] > 1000) vip += 5;
                if (o[1] > 2000) vip += 5;
                if (o[1] > 3000) vip += 5;
                if (o[1] > 4000) vip += 5;
                if (o[1] > 5000) vip += 5;
            }

            return totalRevenue + vip;
        }
    }
}
