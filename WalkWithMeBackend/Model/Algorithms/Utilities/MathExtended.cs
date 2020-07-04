using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalkWithMeBackend.Model.Algorithms.Utilities
{
    public static class MathExtended
    {
        public static int ToRange(this int x,
            int min,
            int max)
        {
            return Math.Max(min, Math.Min(x, max));
        }

        public static double ToRange(this double x,
            double min,
            double max)
        {
            return Math.Max(min, Math.Min(x, max));
        }

        public static int Min(this (int a, int b) x)
        {
            return Math.Min(x.a, x.b);
        }

        public static double Min(this (double a, double b) x)
        {
            return Math.Min(x.a, x.b);
        }

        public static int Max(this (int a, int b) x)
        {
            return Math.Max(x.a, x.b);
        }

        public static double Max(this (double a, double b) x)
        {
            return Math.Max(x.a, x.b);
        }

        public static double Abs(this (double a, double b) x)
        {
            return Math.Abs(x.a - x.b);
        }

        public static double Rel(this (double a, double b) x)
        {
            return x.Abs() / x.b;
        }

        public static double Percantage(this (double a, double b) x)
        {
            return x.a / (x.a + x.b);
        }

        public static double Pow(this double x,
            int degree)
        {
            var a = x;
            for (int i = 1; i < degree; ++i)
            {
                x *= a;
            }

            return x;
        }

        public static double Pow(this double x,
            double degree)
        {
            return Math.Pow(x, degree);
        }
    }
}
