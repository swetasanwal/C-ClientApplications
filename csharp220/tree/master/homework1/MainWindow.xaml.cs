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

namespace homework1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            uxSubmit.IsEnabled = false;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("User and password entered!!!");
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxName.Text != "" && uxPassword.Text != "")
                uxSubmit.IsEnabled = true;
            else
                uxSubmit.IsEnabled = false;
        }


        private void uxName_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (uxPassword.Text != "" && uxName.Text != "")
                uxSubmit.IsEnabled = true;
            else
                uxSubmit.IsEnabled = false;
        }
    }
}
