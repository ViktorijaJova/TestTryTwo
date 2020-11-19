using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.DataModels
{
  public  class Student
    {
        public int Id { get; set;}
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int StudentNumber { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}
