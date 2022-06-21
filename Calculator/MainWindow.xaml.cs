using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = 0;
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                ResultLabel.Content = lastNumber.ToString();
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Division:
                        result = SimpleMath.Div(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Mult(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Sub(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    default:
                        break;
                }
                ResultLabel.Content = result;
            }
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {

            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                ResultLabel.Content = "0";
            }
            switch (((Button)sender).Name.ToString())
            {
                case "DivisionButton":
                    selectedOperator = SelectedOperator.Division;
                    break;
                case "MultiplyButton":
                    selectedOperator = SelectedOperator.Multiplication;
                    break;
                case "SubtractButton":
                    selectedOperator = SelectedOperator.Subtraction;
                    break;
                case "SumButton":
                    selectedOperator = SelectedOperator.Addition;
                    break;
                default:
                    break;
            }

        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedvalue = int.Parse(((Button)sender).Content.ToString());

            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = $"{selectedvalue}";
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content}{selectedvalue}";
            }
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ResultLabel.Content.ToString().Contains("."))
            {
                ResultLabel.Content = $"{ResultLabel.Content}.";
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                ResultLabel.Content = lastNumber.ToString();
            }
        }
    }

    public enum SelectedOperator
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1,double n2)
        {
            return n1 + n2;
        }
        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Mult(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Div(double n1, double n2)
        {
            if (n2 == 0)
            {
                MessageBox.Show("Division by 0 is not supported", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return n1 / n2;
        }
    }
}
