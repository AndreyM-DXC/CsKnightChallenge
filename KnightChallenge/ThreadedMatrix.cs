using System.Numerics;
using System.Text;

namespace KnightChallenge
{
    using TInt = BigInteger;

    public static class ThreadedMatrix
    {
        public static TInt Run(int N)
        {
            if (N <= 0) return 0;

            var matrix = new Matrix10();
            for (var i = 0; i < 10; i++)
            {
                foreach (var j in Moves.All[i])
                {
                    matrix[i, j] = 1;
                }
            }

            var powered = Matrix10.Pow(matrix, N - 1);

            var result = default(TInt);
            foreach (var value in powered.data)
            {
                result += value;
            }
            return result;
        }

        public class Matrix10
        {
            public readonly TInt[] data = new TInt[100];

            public TInt this[int i, int j]
            {
                get => data[i * 10 + j];
                set => data[i * 10 + j] = value;
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                for (int i = 0, k = 0; i < 10; i++)
                {
                    for (var j = 0; j < 10; j++, k++)
                    {
                        sb.Append(data[k]).Append(' ');
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }

            public static Matrix10 Pow(Matrix10 value, int power)
            {
                if (power == 0)
                {
                    return Identity();
                }
                if (power % 2 == 0)
                {
                    var tmp = Pow(value, power / 2);
                    return Mul(tmp, tmp);
                }
                else
                {
                    var tmp = Pow(value, power - 1);
                    return Mul(value, tmp);
                }
            }

            public static Matrix10 Identity()
            {
                var result = new Matrix10();
                for (var i = 0; i < 10; i++)
                {
                    result[i, i] = 1;
                }
                return result;
            }

            public static Matrix10 Mul(Matrix10 m1, Matrix10 m2)
            {
                var result = new Matrix10();
                Parallel.For(0, 10, i =>
                {
                    for (var j = 0; j < 10; j++)
                    {
                        var sum = default(TInt);
                        for (var k = 0; k < 10; k++)
                        {
                            if (m1[i, k] != 0 && m2[k, j] != 0)
                            {
                                sum += m1[i, k] * m2[k, j];
                            }
                        }
                        result[i, j] = sum;
                    }
                });
                return result;
            }
        }
    }
}
