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
        public MainWindow()
        {
            InitializeComponent();

            AcButton.Click += AcButton_Click;
            PercentButton.Click += PercentButton_Click;
            EqualButton.Click += EqualButton_Click;
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = 0;
        }

        private void PercentButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber/100;
                ResultLabel.Content = lastNumber.ToString();
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedvalue = 0;
            switch(((Button)sender).Name.ToString())
            {
                case "ZeroButton":
                    selectedvalue = 0;
                    break;
                case "OneButton":
                    selectedvalue = 1;
                    break;
                case "TwoButton":
                    selectedvalue = 2;
                    break;
                case "ThreeButton":
                    selectedvalue = 3;
                    break;
                case "FourButton":
                    selectedvalue = 4;
                    break;
                case "FiveButton":
                    selectedvalue = 5;
                    break;
                case "SixButton":
                    selectedvalue = 6;
                    break;
                case "SevenButton":
                    selectedvalue = 7;
                    break;
                case "EightButton":
                    selectedvalue = 8;
                    break;
                case "NineButton":
                    selectedvalue = 9;
                    break;
            }
            if (ResultLabel.Content.ToString() == "0"){
                ResultLabel.Content = $"{selectedvalue}";
            }
            else
            {
                ResultLabel.Content = $"{ResultLabel.Content}{selectedvalue}";
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                ResultLabel.Content = lastNumber.ToString();
            }
        }
    }
}
