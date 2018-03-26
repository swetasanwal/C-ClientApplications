using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for StudentEnquiry.xaml
    /// </summary>
    public partial class StudentEnquiry : Window
    {
        public StudentEnquiry()
        {
            InitializeComponent();
        }

        public StudentModel Student { get; set; }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            foreach(UIElement element in uxGrid.Children)
            {
                TextBox textBox = element as TextBox;
                if(textBox != null)
                {
                    textBox.Text = String.Empty;
                }
            }
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

                foreach(var student in students)
                {
                    if(int.Parse(uxID.Text) == student.ID)
                    {
                        uxName.Text = student.Name;
                        uxAddress.Text = student.Address;
                        uxGender.Text = student.Gender;
                        uxDOB.Text = student.DOB;
                        uxPhone.Text = (student.Phone).ToString();
                        uxCourse.Text = student.Course;
                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.StreamSource = new MemoryStream(student.Image);
                        bi.EndInit();
                        uxImage.Source = bi;
                        studentFound = true;
                    }
                }

                if( !studentFound )
                {
                    MessageBox.Show("The entered student id does not exists!");
                    uxID.Text = string.Empty;
                    uxName.Text = string.Empty;
                    uxAddress.Text = string.Empty;
                    uxGender.Text = string.Empty;
                    uxDOB.Text = string.Empty;
                    uxPhone.Text = string.Empty;
                    uxCourse.Text = string.Empty; 
                }
            }
        }
    }
}
