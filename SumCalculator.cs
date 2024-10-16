namespace SumComparison
{
    //Калькулятор суммирования.
    public static class SumCalculator
    {
        // Последовательное.
        public static long SequentialSum(int[] array)
        {
            long sum = 0;

            foreach (int item in array)
            {
                sum += item;
            }

            return sum;
        }

        // Параллельное.
        public static long ParallelSum(int[] array, int numberOfThreads)
        {
            int partialArraysLength = array.Length / numberOfThreads;

            long[] partialArraysSums = new long[numberOfThreads];

            List<Task> tasks = new();

            for (int i = 0; i < numberOfThreads; i++)
            {
                int start = i * partialArraysLength;
                // Тут надо как то лучше считать размер который в последний поток пойдет, но у нас четное кол-во потоков и четные размеры.
                int end = start + partialArraysLength; 
                int threadIndex = i;

                Task task = Task.Run(() =>
                {
                    long sum = 0;
                    for (int j = start; j < end; j++)
                    {
                        sum += array[j];
                    }
                    partialArraysSums[threadIndex] = sum;
                });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());

            long totalSum = 0;

            foreach (var partialArraysSum in partialArraysSums)
            {
                totalSum += partialArraysSum;
            }

            return totalSum;
        }

        // LINQ
        public static long LinqSum(int[] array)
        {
            return array.AsParallel().Sum(x => (long)x);
        }
    }
}
