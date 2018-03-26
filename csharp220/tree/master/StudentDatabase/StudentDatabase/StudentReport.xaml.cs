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
    /// Interaction logic for StudentReport.xaml
    /// </summary>
    public partial class StudentReport : Window
    {
        public StudentReport()
        {
            InitializeComponent();
            LoadContacts();
        }

        public StudentModel Student { get; set; }
        private void LoadContacts()
        {
            var students = App.StudentRepository.GetAll();

            uxStudentList.ItemsSource = students
                .Select(t => StudentModel.ToModel(t))
                .ToList();
        }
    }
}
