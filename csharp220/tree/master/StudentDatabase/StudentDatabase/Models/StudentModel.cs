using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace StudentDatabase.Models
{
    public class StudentModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public int Phone { get; set; }
        public string Course { get; set; }
        public byte[] Image { get; set; }
        //public BitmapImage Image { get; set; }

        public StudentRepository.StudentModel ToRepositoryModel()
        {
            var repositoryModel = new StudentRepository.StudentModel
            {
                ID = ID,
                Name = Name,
                Address = Address,
                Gender = Gender,
                DOB = DOB,
                Phone = Phone,
                Course = Course,
                Image = Image
            };
            return repositoryModel;
        }

        public static StudentModel ToModel(StudentRepository.StudentModel respositoryModel)
        {
            var studentModel = new StudentModel
            {
                ID = respositoryModel.ID,
                Name = respositoryModel.Name,
                Address = respositoryModel.Address,
                Gender = respositoryModel.Gender,
                DOB = respositoryModel.DOB,
                Phone = respositoryModel.Phone,
                Course = respositoryModel.Course,
                Image = respositoryModel.Image
            };

            return studentModel;
        }
    }
}
