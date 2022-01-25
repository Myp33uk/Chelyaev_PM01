using System;
using System.Windows;
using System.Windows.Input;
using LibTasks;

namespace Chelyaev_PM01
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Task1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int rezult = Moduls.Task1(int.Parse(inputTask1.Text));
                if (rezult > 0) outputTask1.Text = "Первая цифра больше второй";
                if (rezult < 0) outputTask1.Text = "Первая цифра меньше второй";
                if (rezult == 0) outputTask1.Text = "Первая цифра равна второй";
            }
            catch
            {
                MessageBox.Show("Неверные данные", "Ошибка", MessageBoxButton.OK);
            }
        }

        private void Task2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int a = int.Parse(inputATask2.Text);
                int b = int.Parse(inputBTask2.Text);
                int c = int.Parse(inputCTask2.Text);
                outputTask2.Text = Moduls.Task2(a, b, c).ToString();
            }
            catch
            {
                MessageBox.Show("Неверные данные", "Ошибка", MessageBoxButton.OK);
            }
        }
        private void Task3_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(inputColumnsTask3.Text, out int lenght))
            {
                MessageBox.Show("Неверные данные", "Ошибка", MessageBoxButton.OK);
                return;
            }
            outputTask3.Text = string.Empty;
            outputMatrTask3.Text = string.Empty;
            int[] array = new int[lenght];
            Random rnd = new Random();
            for (int i = 0; i < lenght; i++)
            {
                array[i] = rnd.Next(-10, 101);
                outputMatrTask3.Text += array[i].ToString() + ", ";
            }
            Moduls.Task3(array, out int count, out int sum);
            outputTask3.Text = "Сумма: " + sum + "   Количество: " + count;
        }

        private int[,] _matrix;
        private void Task4CreateMatr_Click(object sender, RoutedEventArgs e)
        {
            //Проверяем введенные данные
            if (!int.TryParse(rowKol.Text, out int row) || !int.TryParse(colCount.Text, out int column))
            {
                MessageBox.Show("Неверные данные", "Ошибка", MessageBoxButton.OK);
                return;
            }
            //Заполняем массив случайными числами
            _matrix = new int[row, column];
            Random rnd = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    _matrix[i, j] = rnd.Next(-10, 11);
                }
            }
            //Выводим массив на форму
            matrTable.ItemsSource = VisualArray.ToDataTable(_matrix).DefaultView;
            outputTask4.Text = string.Empty;
        }
        private void Task4Rezult_Click(object sender, RoutedEventArgs e)
        {
            if (_matrix == null || _matrix.Length == 0)
            {
                MessageBox.Show("Создайте матрицу!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            outputTask4.Text = "Номер строки: " + Moduls.Task4(_matrix).ToString();
        }

        private void TextBox_PrewInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out _)) e.Handled = true;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Разработчик - Челяев Никита ИСП-31\nЗадания: \n\n" +
                "1. Ввести двузначное число. Определить: какая из его цифр больше: первая или вторая\n\n" +
                "2. Ввести три целых числа. Подсчитать кол-во чисел, которые являются четными\n\n" +
                "3. Найти количество и сумму тех членов массива а1,..,аn, которые делятся на 5 и не делятся на 7.\n\n" +
                "4. Дана целочисленная матрица размера M * N. Найти номер последней из ее строк, содержащих только четные числа.Если таких строк нет, то вывести 0.",
                "Задания", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
