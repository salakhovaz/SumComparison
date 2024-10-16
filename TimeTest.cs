using System.Diagnostics;

namespace SumComparison
{
    //Тестирование по времени.
    public static class TimeTest
    {
        //Запускает тестирование по времени для последовательного и LINQ суммирования.
        public static TimeTestResult RunTestForSequentialAndLinq(int[] array)
        {
            TimeTestResult result = new ();
            Stopwatch sw = new();

            // Последовательное.
            sw.Start();
            result.SequentialSum = SumCalculator.SequentialSum(array);
            sw.Stop();
            result.SequentialTime = sw.ElapsedMilliseconds;

            // LINQ.
            sw.Start();
            result.LinqSum = SumCalculator.LinqSum(array);
            sw.Stop();
            result.LinqTime = sw.ElapsedMilliseconds;

            return result;
        }

        //Запускает тестирование по времени для параллельного суммирования. 
        public static TimeTestResult RunTestForParallel(int[] array, int numberOfThreads)
        {
            TimeTestResult result = new();
            Stopwatch sw = new();

            // Параллельное.
            sw.Start();
            result.ParallelSum = SumCalculator.ParallelSum(array, numberOfThreads);
            sw.Stop();
            result.ParallelTime = sw.ElapsedMilliseconds;

            return result;
        }
    }
}
