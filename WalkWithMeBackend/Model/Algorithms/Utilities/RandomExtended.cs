using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model.Algorithms.Utilities
{
    public static class RandomExtended
    {
        private static Random Random { get; } = new Random();

        public static int Rand(this (int min, int max) x)
        {
            return Random.Next(x.min, x.max);
        }

        public static double Rand(this (double min, double max) x)
        {
            return x.min + x.Abs() * Random.NextDouble();
        }

        public static bool Success(this double x)
        {
            return (0.0, 1.0).Rand() <= x;
        }

        public static double NormalDistribution(this (double exp, double var) x)
        {
            var sum = -6.0;
            for (int i = 0; i < 12; ++i)
            {
                sum += Random.NextDouble();
            }

            return x.exp + sum * Math.Sqrt(x.var);
        }

        public static T RandBy<T>(this List<T> ts)
        {
            var ind = Random.Next(0, ts.Count);

            return ts[ind];
        }

        public static T RandBy<T>(this List<T> ts,
            Func<T, double> p)
        {
            var sum = ts.Select(t => p(t)).Sum();
            var i = -1;

            while (sum > 0)
            {
                ++i;
                sum -= p(ts[i]);
            }

            return ts[i];
        }
    }
}
