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
using StudentDatabase.Models;

namespace StudentDatabase
{
    /// <summary>
    /// Interaction logic for StudentDelete.xaml
    /// </summary>
    public partial class StudentDelete : Window
    {
        public StudentDelete()
        {
            InitializeComponent();
            uxID.Focus();
        }

        public StudentModel Student { get; set; }

        private void uxID_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (!(e.KeyboardDevice.Modifiers == ModifierKeys.Shift)
            && e.KeyboardDevice.IsKeyDown(Key.Tab))
            {
                var students = App.StudentRepository.GetAll();
                bool studentFound = false;

                foreach (var student in students)
                {
                    if (int.Parse(uxID.Text) == student.ID)
                    {
                        uxName.Text = student.Name;
                        uxAddress.Text = student.Address;
                        uxGender.Text = student.Gender;
                        uxDOB.Text = student.DOB;
                        uxPhone.Text = (student.Phone).ToString();
                        uxCourse.Text = student.Course;
                        studentFound = true;
                        uxDelete.IsEnabled = true;

                    }
                }

                if (!studentFound)
                {
                    MessageBox.Show("Specified ID does not match any record!");
                    uxID.Text = string.Empty;
                }
            }
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            foreach(UIElement element in uxGrid.Children)
            {
                TextBox textBox = element as TextBox;
                if(textBox != null)
                {
                    textBox.Text = string.Empty;
                }
            }
            uxDelete.IsEnabled = false;
        }

        private void uxDelete_Click(object sender, RoutedEventArgs e)
        {
            Student = new StudentModel();
            Student.ID = int.Parse(uxID.Text);

            var students = App.StudentRepository.GetAll();

            foreach (var student in students)
            {
                if (int.Parse(uxID.Text) == student.ID)
                {
                    App.StudentRepository.Remove(Student.ID);
                    MessageBox.Show("Record deleted successfully!");
                    Close();
                }
            }
        }

        private void uxHome_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
