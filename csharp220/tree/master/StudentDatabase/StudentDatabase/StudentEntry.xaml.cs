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
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using System.IO;
using System.Globalization;

namespace StudentDatabase
{
    /// <summary>
    /// Interaction logic for StudentEntry.xaml
    /// </summary>
    public partial class StudentEntry : Window
    {
        public StudentEntry()
        {
            InitializeComponent();
        }

        public StudentModel Student { get; set; }
        private byte[] _imageBytes = null;
        private bool checkIDExists(int ID)
        {
            var students = App.StudentRepository.GetAll();

            foreach(var student in students)
            {
                if(student.ID == ID)
                {
                    uxID.Foreground = Brushes.Red;
                    return true;
                }
            }
            return false;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Student = new StudentModel();
            bool idExists = false;

            Student.ID = int.Parse(uxID.Text);
            if(checkIDExists(Student.ID))
            {
                MessageBox.Show($"Id entered exists {uxID.Text}");
                idExists = true;
            }

            Student.Name = uxName.Text;
            Student.Address = uxAddress.Text;

            Student.Gender = uxGender.Text;
            Student.DOB = uxDOB.Text;
            Student.Phone = int.Parse(uxPhone.Text);
            Student.Course = uxCourse.Text;
            Student.Image = File.ReadAllBytes(uxImagePath.Text);


            if (!idExists)
            {
                DialogResult = true;
                MessageBox.Show("Student Registered successfully!");
                Close();
            }
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement element in uxGrid.Children)
            {
                TextBox textBox = element as TextBox;
                if(textBox != null)
                {
                    textBox.Text = string.Empty;
                }
            }
        }

        private void uxHome_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                uxImagePath.Text = op.FileName;
                imgPhoto.Source = new BitmapImage(new Uri(uxImagePath.Text));
            }
        }

        

    }
}
