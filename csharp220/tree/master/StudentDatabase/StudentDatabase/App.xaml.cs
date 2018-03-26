using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudentDatabase
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static StudentRepository.StudentRepository studentRepository;

        static App()
        {
            studentRepository = new StudentRepository.StudentRepository();
        }

        public static StudentRepository.StudentRepository StudentRepository
        {
            get
            {
                return studentRepository;
            }
        }
    }
}
