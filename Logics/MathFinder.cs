using System;
using System.Collections.Generic;

namespace ET_7_8_Square_Fibonacci.Logics
{
    public class MathFinder : ISquareSeriesFinder, IFibonacciSeriesMaker
    {
        public int[] GetSquareSeries(int end)
        {
            List<int> result = new List<int>();

            for(int i = 0; i < Math.Sqrt(end); i++)
            {
                result.Add(i);
            }

            return result.ToArray();
        }

        public int[] GetFibonacciSeries(int start, int end)
        {
            List<int> result = new List<int>();
            int fibonacciPrevious = 0;
            int fibonacciNow = 1;
            int tempNow = 0;

            while (fibonacciNow < end)
            {
                tempNow = fibonacciPrevious + fibonacciNow;
                if (fibonacciNow > start)
                {
                    result.Add(fibonacciNow);
                }
                fibonacciPrevious = fibonacciNow;
                fibonacciNow = tempNow;
            }

            return result.ToArray();
        }
    }
}
