using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDB;

namespace StudentRepository
{
    class DatabaseManager
    {
        private static readonly StudentsEntities3 entities;

        static DatabaseManager()
        {
            entities = new StudentsEntities3();
            entities.Database.Connection.Open();
        }

        public static StudentsEntities3 Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
