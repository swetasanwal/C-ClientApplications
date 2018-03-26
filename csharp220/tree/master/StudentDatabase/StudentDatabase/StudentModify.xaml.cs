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
    /// Interaction logic for StudentModify.xaml
    /// </summary>
    public partial class StudentModify : Window
    {
        public StudentModify()
        {
            InitializeComponent();
        }

        public StudentModel Student { get; set; }
        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in uxGrid.Children)
            {
                TextBox textBox = element as TextBox;
                if (textBox != null)
                {
                    textBox.Text = String.Empty;
                }
            }
            uxUpdate.IsEnabled = false;
        }

        private void uxHome_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

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
                        uxNameNew.Text = student.Name;
                        uxAddress.Text = student.Address;
                        uxAddressNew.Text = student.Address;
                        uxGender.Text = student.Gender;
                        uxGenderNew.Text = student.Gender;
                        uxDOB.Text = student.DOB;
                        uxDOBNew.Text = student.DOB;
                        uxPhone.Text = (student.Phone).ToString();
                        uxPhoneNew.Text = (student.Phone).ToString();
                        uxCourse.Text = student.Course;
                        uxCourseNew.Text = student.Course;
                        uxUpdate.IsEnabled = true;
                        studentFound = true;
                    }
                }

                if (!studentFound)
                {
                    MessageBox.Show("Record for specified ID does not exist!");
                    uxID.Text = string.Empty;
                    uxName.Text = string.Empty;
                    uxNameNew.Text = string.Empty;
                    uxAddress.Text = string.Empty;
                    uxAddressNew.Text = string.Empty;
                    uxGender.Text = string.Empty;
                    uxGenderNew.Text = string.Empty;
                    uxDOB.Text = string.Empty;
                    uxDOBNew.Text = string.Empty;
                    uxPhone.Text = string.Empty;
                    uxPhoneNew.Text = string.Empty;
                    uxCourse.Text = string.Empty;
                    uxCourseNew.Text = string.Empty;
                    uxUpdate.IsEnabled = false;
                }
            }
        }

        private void uxUpdate_Click(object sender, RoutedEventArgs e)
        {
            Student = new StudentModel();
            Student.ID = int.Parse(uxID.Text);
            Student.Name = uxNameNew.Text;
            Student.Address = uxAddressNew.Text;
            Student.Gender = uxGenderNew.Text;
            Student.DOB = uxDOBNew.Text;
            Student.Course = uxCourseNew.Text;
            Student.Phone = int.Parse(uxPhoneNew.Text);

            App.StudentRepository.Update(Student.ToRepositoryModel());
            MessageBox.Show("Updated Student Record!");
            Close();
        }
    }
}
