namespace SumComparison
{
    //Генератор массива.
    public static class ArrayGenerator
    {
        //Генерирует и возвращает массив, заполненный интами.
        public static int[] GenerateArray(int size, int minValue = 1, int maxValue = 500)
        {
            Random rand = new();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(minValue, maxValue);
            }

            return array;
        }
    }
}
