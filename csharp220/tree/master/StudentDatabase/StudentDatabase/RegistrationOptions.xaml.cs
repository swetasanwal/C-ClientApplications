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
using System.Windows.Shapes;

namespace StudentDatabase
{
    /// <summary>
    /// Interaction logic for RegistrationOptions.xaml
    /// </summary>
    public partial class RegistrationOptions : Window
    {
        public RegistrationOptions()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var window = new StudentEntry();

            if (window.ShowDialog() == true)
            {
                var uiStudentModel = window.Student;

                var repositoryStudentModel = uiStudentModel.ToRepositoryModel();

                App.StudentRepository.Add(repositoryStudentModel);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var window = new StudentEnquiry();

            if (window.ShowDialog() == true)
            {
                var uiStudentModel = window.Student;

                var repositoryStudentModel = uiStudentModel.ToRepositoryModel();

                App.StudentRepository.Add(repositoryStudentModel);
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var window = new StudentModify();

            if (window.ShowDialog() == true)
            {
                var uiStudentModel = window.Student;

                var repositoryStudentModel = uiStudentModel.ToRepositoryModel();

                App.StudentRepository.Add(repositoryStudentModel);
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var window = new StudentDelete();

            if (window.ShowDialog() == true)
            {
                var uiStudentModel = window.Student;

                var repositoryStudentModel = uiStudentModel.ToRepositoryModel();

                App.StudentRepository.Add(repositoryStudentModel);
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            var window = new StudentReport();
            if (window.ShowDialog() == true)
            {
                var uiStudentModel = window.Student;

                var repositoryStudentModel = uiStudentModel.ToRepositoryModel();

                App.StudentRepository.Add(repositoryStudentModel);
            }
        }
    }
}
