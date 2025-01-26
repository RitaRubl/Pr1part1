using System;
using System.Windows;

namespace PracticalWork1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(InputTextBox.Text))
                {
                    MessageBox.Show("Введите значение для расчета.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                double input = double.Parse(InputTextBox.Text);
                double result = 0;

                if (ShRadioButton.IsChecked == true)
                {
                    result = Math.Sinh(input); // Вычисление гиперболического синуса
                }
                else if (SquareRadioButton.IsChecked == true)
                {
                    result = Math.Pow(input, 2); // Квадрат числа
                }
                else if (ExpRadioButton.IsChecked == true)
                {
                    result = Math.Exp(input); // Экспонента
                }

                ResultTextBox.Text = result.ToString(); // Вывод результата
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите корректное числовое значение.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Clear();
            ResultTextBox.Clear();
            ShRadioButton.IsChecked = false;
            SquareRadioButton.IsChecked = false;
            ExpRadioButton.IsChecked = false;
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?",
                                         "Подтверждение",
                                         MessageBoxButton.YesNo,
                                         MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
