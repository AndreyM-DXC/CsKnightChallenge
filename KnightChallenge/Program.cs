using System.Diagnostics;
using System.Numerics;

namespace KnightChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Validate(Naive.Run);
            Validate(Memoized.Run);
            Validate(BFS.Run);
            Validate(Matrix.Run);
            Validate(ThreadedMatrix.Run);

            Estimate(20, Naive.Run);
            Estimate(5000, Memoized.Run);
            Estimate(100_000, BFS.Run);
            Estimate(500_000, Matrix.Run);
            Estimate(2_000_000, ThreadedMatrix.Run);
        }

        private static void Validate(Func<int, BigInteger> func)
        {
            Debug.WriteLine($"--- {func.Method.DeclaringType}.{func.Method.Name} ---");

            for (var N = 0; N <= 15; N++)
            {
                var sw = Stopwatch.StartNew();
                var actual = func(N);
                sw.Stop();

                var expected = Printed.Run(N).Count;
                var result = actual == expected ? "OK" : "FAIL";
                Debug.WriteLine($"{result} N: {N} Actual: {actual} Expected: {expected} Time: {sw.ElapsedMilliseconds}ms");
            }
            Debug.WriteLine("");
        }

        private static void Estimate(int N, Func<int, BigInteger> func)
        {
            Debug.WriteLine($"--- {func.Method.DeclaringType}.{func.Method.Name} ---");
            var sw = Stopwatch.StartNew();
            func(N);
            sw.Stop();
            Debug.WriteLine($"N: {N} Time: {sw.ElapsedMilliseconds}ms");
            Debug.WriteLine("");
        }
    }
}