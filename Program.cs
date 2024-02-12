//
// inspired by b001 video on Dijkstra's prime finding algorithm
// https://www.youtube.com/watch?v=fwxjMKBMR7s
//


namespace Dijkstra_Prime_Finding_Algorithm
{
    internal class Program
    {
        static void Main()
        {
            static void PrintArr(int[] arr)
            {
                foreach (int i in arr) Console.Write($"{i}, ");
                Console.WriteLine();
            }
            PrintArr(DijkstraPrimes(1000));
            Console.ReadKey();
        }
        static int[] DijkstraPrimes(int upTo)
        {
            if (upTo < 2) return [];
            List<PoolNum> pool = [new PoolNum(2)];
            List<int> primes = [2];
            bool belowSQRT = true;
            for (int i = 3; i < upTo; i++)
            {
                bool prime = true;
                foreach (PoolNum num in pool)
                {
                    if (i == num.multiple)
                    {
                        prime = false;
                        num.IncreaseMultiple();
                    }
                }
                if (prime)
                {
                    primes.Add(i);
                    if (belowSQRT)
                    {
                        pool.Add(new PoolNum(i));
                        belowSQRT = i * i < upTo;
                    }
                }
            }
            return [.. primes];
        }
        class PoolNum(int prime)
        {
            public readonly int Prime = prime;
            public int multiple = prime * prime;
            public void IncreaseMultiple()
            {
                multiple += Prime;
            }
        }
    }
}
