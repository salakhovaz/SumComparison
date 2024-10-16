namespace SumComparison
{
    //Результаты тестирования по времени.
    public class TimeTestResult
    {
        public long SequentialTime { get; set; }
        public long ParallelTime { get; set; }
        public long LinqTime { get; set; }
        public long SequentialSum { get; set; }
        public long ParallelSum { get; set; }
        public long LinqSum { get; set; }
    }
}
