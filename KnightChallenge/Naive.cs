using System.Numerics;

namespace KnightChallenge
{
    public static class Naive
    {
        public static BigInteger Run(int N)
        {
            if (N <= 0) return 0;

            var result = 0;
            for (var i = 0; i < 10; i++)
            {
                result += Count(N - 1, i);
            }
            return result;
        }

        private static int Count(int hops, int start)
        {
            if (hops == 0)
            {
                return 1;
            }
            var result = 0;
            foreach (var next in Moves.All[start])
            {
                result += Count(hops - 1, next);
            }
            return result;
        }
    }
}
