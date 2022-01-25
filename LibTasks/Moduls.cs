using System;

namespace LibTasks
{
    public class Moduls
    {
        /// <summary>
        /// Определяет какая цифра двухзначного числа больше - первая или вторая
        /// </summary>
        /// <param name="number"> двухзначное число</param>
        /// <returns>возвращает разницу между цифрами. Положительный результат говорит о том,
        /// что первая цифра больше, отрицательный, что вторая цифра больше, а 0 означает, что цифры равны</returns>
        public static int Task1(int number)
        {
            return number / 10 - number % 10;
        }
        /// <summary>
        /// Вводят 3 числа
        /// Считает количество чётных цифр
        /// </summary>
        /// <param name="firstArg"> первое число</param>
        /// <param name="secondArg">второе число</param>
        /// <param name="thirdArg"> третье число</param>
        /// <returns>Возвращает количество чётных чисел</returns>
        public static int Task2(int firstArg, int secondArg, int thirdArg)
        {
            int count = 0;
            if (firstArg % 2 == 0) count++;
            if (secondArg % 2 == 0) count++;
            if (thirdArg % 2 == 0) count++;
            return count;
        }
        /// <summary>
        ///  Находит количество и сумму тех членов массива, которые делятся на 5 и не делятся на 7.
        /// </summary>
        /// <param name="array">массив</param>
        /// <param name="count">количество удовлетворяющих условию чисел</param>
        /// <param name="sum">сумма удовлетворяющих условию чисел</param>
        public static void Task3(int[] array, out int count, out int sum)
        {
            count = 0;
            sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 5 == 0 && array[i] / 7 != 0)
                {
                    count++;
                    sum += array[i];
                }
            }
        }
        /// <summary>
        /// Находит номер последней из строк матрицы, содержащих только четные числа.
        /// </summary>
        /// <param name="matrix">матрица</param>
        /// <returns>Возвращает 0 в случае, если строк, удовлетворяющих условию, нет</returns>
        public static int Task4(int[,] matrix)
        {
            int row = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] % 2 == 0) count++;
                }
                if (count == matrix.GetLength(1)) row = i + 1;
            }
            return row;
        }
    }
}
