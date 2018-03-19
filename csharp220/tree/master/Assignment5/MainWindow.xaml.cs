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

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _firstPlayer = true;
        public string[,] gridvalues = new string[3, 3];

        public MainWindow()
        {
            InitializeComponent();

        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            foreach(DependencyObject c in uxGrid.Children)
            {
                Button b = c as Button;
                b.Content = "";
                b.IsEnabled = true;
            }
            _firstPlayer = true;
            gridvalues = new string[3, 3];
            uxGrid.IsEnabled = true;
        }

        private void check_all_rows()
        {
            int firstWinner = 0;
            int secondWinner = 0;

            for (int i = 0; i < 3; i++)
            {
                firstWinner = 0;
                secondWinner = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (gridvalues[i, j] == "X")
                    {
                        firstWinner++;
                    }
                    if (gridvalues[i, j] == "O")
                    {
                        secondWinner++;
                    }

                    if (firstWinner == 3)
                    {
                        MessageBox.Show("Player 1 Wins !!");
                        uxTurn.Text = "X is a winner";
                        uxGrid.IsEnabled = false;
                        break;
                    }
                    if (secondWinner == 3)
                    {
                        MessageBox.Show("Player 2 Wins !!");
                        uxTurn.Text = "O is a winner";
                        uxGrid.IsEnabled = false;
                        break;
                    }
                }
            }
        }

        private void check_all_columns()
        {
            int firstWinner = 0;
            int secondWinner = 0;

            for (int i = 0; i < 3; i++)
            {
                firstWinner = 0;
                secondWinner = 0;

                for (int j = 0; j < 3; j++)
                {
                    if (gridvalues[j, i] == "X")
                    {
                        firstWinner++;
                    }
                    if (gridvalues[j, i] == "O")
                    {
                        secondWinner++;
                    }

                    if (firstWinner == 3)
                    {
                        MessageBox.Show("Player 1 Wins !!");
                        uxTurn.Text = "X is a winner";
                        uxGrid.IsEnabled = false;
                        break;
                    }
                    if (secondWinner == 3)
                    {
                        MessageBox.Show("Player 2 Wins !!");
                        uxTurn.Text = "O is a winner";
                        uxGrid.IsEnabled = false;
                        break;
                    }
                }
            }
        }

        private void check_all_diagonals()
        {
            int firstWinner = 0;
            int secondWinner = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j && gridvalues[j, i] == "X")
                    {
                        firstWinner++;
                    }
                    if (i == j && gridvalues[j, i] == "O")
                    {
                        secondWinner++;
                    }

                    if (firstWinner == 3)
                    {
                        MessageBox.Show("Player 1 Wins !!");
                        uxTurn.Text = "X is a winner";
                        uxGrid.IsEnabled = false;
                        break;
                    }
                    if (secondWinner == 3)
                    {
                        MessageBox.Show("Player 2 Wins !!");
                        uxTurn.Text = "O is a winner";
                        uxGrid.IsEnabled = false;
                        break;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int row = Grid.GetRow(b);
            int col = Grid.GetColumn(b);

            if (_firstPlayer)
            {
                b.Content = "X";
                b.IsEnabled = false;
                _firstPlayer = false;
                gridvalues[row, col] = "X";
            }
            else
            {
                b.Content = "O";
                b.IsEnabled = false;
                _firstPlayer = true;
                gridvalues[row, col] = "O";
            }

            check_all_rows();
            check_all_columns();
            check_all_diagonals();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
