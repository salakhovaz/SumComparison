using SumComparison;

int[] sizes = { 100000, 1000000, 10000000, 1000000000 };
int[] threadCounts = { 2, 4, 8 };

Console.WriteLine($"Окружение: ОС {Environment.OSVersion}, Процессор {Environment.ProcessorCount} ядер, .NET 8");

foreach (int size in sizes)
{
    Console.WriteLine(new string('-', 40));
    Console.WriteLine($"\nРазмер массива: {size}");

    int[] array = ArrayGenerator.GenerateArray(size);

    // Последовательное и LINQ суммирование.
    TimeTestResult seqLinqResult = TimeTest.RunTestForSequentialAndLinq(array);

    Console.WriteLine($"\nПоследовательное: {seqLinqResult.SequentialTime} мс, Сумма: {seqLinqResult.SequentialSum}");
    Console.WriteLine($"\nLINQ: {seqLinqResult.LinqTime} мс, Сумма: {seqLinqResult.LinqSum}");

    // Параллельное суммирование.
    foreach (int threads in threadCounts)
    {
        Console.WriteLine($"\nПараллельное с {threads} потоками:");

        TimeTestResult parallelResult = TimeTest.RunTestForParallel(array, threads);

        Console.WriteLine($"Параллельное: {parallelResult.ParallelTime} мс, Сумма: {parallelResult.ParallelSum}");
    }
}
