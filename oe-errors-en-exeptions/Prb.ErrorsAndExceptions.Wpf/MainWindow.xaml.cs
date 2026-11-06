using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Prb.ErrorsAndExceptions.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sum_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int numberLeft = int.Parse(txtNumber1.Text);
                int numberRight = int.Parse(txtNumber2.Text); //parse string to int
                int sum = CalculateSum(numberLeft, numberRight);
                tbResult.Text = sum.ToString(); //convert int back to string and set in textblock
            }
            catch (FormatException fEx)
            {
                MessageBox.Show("Please enter integer values only.\n\nDetails: " + fEx.Message,
                                "Input error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex) //catches all unhandled exceptions (FormatException are already handled above)
            {
                //generic error message is shown
                MessageBox.Show("An error has occurred.\n\nDetails: " + ex.Message,
                                "Input error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                //always write to output window (in Visual Studio)
                Debug.WriteLine("Last execution: {0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);
            }
        }

        /// <summary>
        /// Calculates the sum of two numbers
        /// </summary>
        private int CalculateSum(int number1, int number2)
        {
            //check if either number is negative
            if (number1 < 0 || number2 < 0)
            {
                throw new ArgumentOutOfRangeException("Terms should not be negative");
            }
            //this instruction will only be executed reached if no exception occurred
            return checked(number1 + number2);
        }
    }
}
