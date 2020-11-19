using System;
using System.Collections.Generic;
using System.Text;
using Testing.DataModels;

namespace Testing.DataAccess.Repos
{
  public  class SubjectRepository: IRepository<Subject>
    {
        private readonly SystemDbContext _systemcontext;

        public SubjectRepository(SystemDbContext systemcontext)
        {
            _systemcontext = systemcontext;
        }




        public IEnumerable<Subject> GetAll()
        {
            return _systemcontext.Subjects;
        }

        public void Insert(Subject entity)
        {
            _systemcontext.Subjects.Add(entity);
            _systemcontext.SaveChanges();
        }

        public void Remove(Subject entity)
        {
            _systemcontext.Subjects.Remove(entity);
            _systemcontext.SaveChanges();
        }

        public void Update(Subject entity)
        {
            _systemcontext.Subjects.Update(entity);
            _systemcontext.SaveChanges();
        }
    }
}
