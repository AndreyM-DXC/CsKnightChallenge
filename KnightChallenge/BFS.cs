using System.Numerics;

namespace KnightChallenge
{
    using TInt = BigInteger;

    public static class BFS
    {
        public static TInt Run(int N)
        {
            if (N <= 0) return 0;

            var prev = new TInt[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            var next = new TInt[10];

            for (var hop = 1; hop < N; hop++)
            {
                for (var i = 0; i < prev.Length; i++)
                {
                    if (prev[i] > 0)
                    {
                        foreach (var j in Moves.All[i])
                        {
                            next[j] += prev[i];
                        }
                    }
                }
                var t = prev;
                prev = next;
                next = t;
                Array.Clear(next, 0, next.Length);
            }

            var result = default(TInt);
            foreach (var value in prev)
            {
                result += value;
            }
            return result;
        }
    }
}
