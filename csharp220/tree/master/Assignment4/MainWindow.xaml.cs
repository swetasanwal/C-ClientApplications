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
using System.Text.RegularExpressions;

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxsubmit.IsEnabled = false;
        }

        private void USZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            string matchStr = @"^\b\d{5}$\b";
            string matchStr1 = @"\b^\d{5}-\d{4}$\b";

            if(Regex.IsMatch(USZipCode.Text, matchStr) || Regex.IsMatch(USZipCode.Text, matchStr1))
            {
                uxsubmit.IsEnabled = true;
            } else
            {
                uxsubmit.IsEnabled = false;
            }

        }

        private void CanadaPostal_TextChanged(object sender, TextChangedEventArgs e)
        {
            string matchStr = @"\b^[A-Z]\d[A-Z]\d[A-Z]\d$\b";

            if(Regex.IsMatch(CanadaPostal.Text, matchStr))
            {
                uxsubmit.IsEnabled = true;
            } else
            {
                uxsubmit.IsEnabled = false;
            }
        }

        private void uxsubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Entered Text Is Correct!!!");
        }
    }
}
