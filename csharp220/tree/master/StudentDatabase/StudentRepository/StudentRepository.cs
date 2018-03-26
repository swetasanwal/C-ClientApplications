using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using StudentDB;

namespace StudentRepository
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
    }


    public class StudentRepository
    {
        public StudentModel Add(StudentModel studentModel)
        {
            var studentDb = ToDbModel(studentModel);

            DatabaseManager.Instance.Students.Add(studentDb);
            DatabaseManager.Instance.SaveChanges();

            studentModel = new StudentModel
            {
                ID = studentDb.StudentId,
                Name = studentDb.StudentName,
                Address = studentDb.StudentAddress,
                Gender = studentDb.StudentGender,
                DOB = studentDb.StudentDOB,
                Phone = studentDb.StudentPhone,
                Course = studentDb.StudentCourse,
                Image = studentDb.StudentImage
                
            };
            return studentModel;
        }

        public List<StudentModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.Students
              .Select(t => new StudentModel
              {
                  ID = t.StudentId,
                  Name = t.StudentName,
                  Address = t.StudentAddress,
                  Gender = t.StudentGender,
                  DOB = t.StudentDOB,
                  Phone = t.StudentPhone,
                  Course = t.StudentCourse,
                  Image = t.StudentImage
              }).ToList();

            return items;
        }

        public bool Update(StudentModel studentModel)
        {
            var original = DatabaseManager.Instance.Students.Find(studentModel.ID);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(studentModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int studentId)
        {
            var items = DatabaseManager.Instance.Students
                                .Where(t => t.StudentId == studentId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Students.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }
        private Student ToDbModel(StudentModel studentModel)
        {
            var studentDb = new Student
            {
                StudentId = studentModel.ID,
                StudentName = studentModel.Name,
                StudentAddress = studentModel.Address,
                StudentGender = studentModel.Gender,
                StudentDOB = studentModel.DOB,
                StudentCourse = studentModel.Course,
                StudentPhone = studentModel.Phone,
                StudentImage = studentModel.Image
            };

            return studentDb;
        }
    }
}
