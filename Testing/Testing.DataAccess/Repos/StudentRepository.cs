using System;
using System.Collections.Generic;
using System.Text;
using Testing.DataModels;

namespace Testing.DataAccess.Repos
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly SystemDbContext _systemcontext;

        public StudentRepository(SystemDbContext systemcontext)
        {
            _systemcontext = systemcontext;
        }
        public IEnumerable<Student> GetAll()
        {
            return _systemcontext.Students;
        }

        public void Insert(Student entity)
        {
            _systemcontext.Students.Add(entity);
            _systemcontext.SaveChanges();
        }

        public void Remove(Student entity)
        {
            _systemcontext.Students.Remove(entity);
            _systemcontext.SaveChanges();

        }

        public void Update(Student entity)
        {
            _systemcontext.Students.Update(entity);
            _systemcontext.SaveChanges();

        }

    }
}
