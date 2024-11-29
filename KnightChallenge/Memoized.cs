using System.Numerics;

namespace KnightChallenge
{
    using TInt = BigInteger;

    public static class Memoized
    {
        public static TInt Run(int N)
        {
            if (N <= 0) return 0;

            var memory = new Dictionary<(int hops, int start), TInt>();
            var result = default(TInt);
            for (var i = 0; i < 10; i++)
            {
                result += Count(N - 1, i, memory);
            }
            return result;
        }

        private static TInt Count(int hops, int start, Dictionary<(int, int), TInt> memory)
        {
            if (hops == 0)
            {
                return 1;
            }
            var result = default(TInt);
            var key = (hops, start);

            if (!memory.TryGetValue(key, out result))
            {
                foreach (var next in Moves.All[start])
                {
                    result += Count(hops - 1, next, memory);
                }
                memory.Add(key, result);
            }
            return result;
        }
    }
}
