
namespace KnightChallenge
{
    public static class Printed
    {
        public static List<string> Run(int N)
        {
            var result = new List<string>();

            if (N <= 0) return result;

            for (var i = 0; i < 10; i++)
            {
                Count(N - 1, i, i.ToString(), result);
            }
            return result;
        }

        private static void Count(int hops, int start, string prefix, List<string> result)
        {
            if (hops == 0)
            {
                result.Add(prefix);
            }
            else
            {
                foreach (var next in Moves.All[start])
                {
                    Count(hops - 1, next, prefix + next, result);
                }
            }
        }
    }
}
