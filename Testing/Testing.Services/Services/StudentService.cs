using System;
using System.Collections.Generic;
using System.Text;
using Testing.DataAccess;
using Testing.DataModels;

namespace Testing.Services.Services
{
    public class StudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Register(Student student1)
        {

            if (string.IsNullOrWhiteSpace(student1.FullName))
            {
                throw new Exception("enter your  full name");
            }


            if (string.IsNullOrWhiteSpace(student1.EmailAddress))
            {
                throw new Exception("Enter your email address!");
            }

            if (string.IsNullOrWhiteSpace(student1.PhoneNumber))
            {
                throw new Exception("Enter your phone number!");
            }


            Student student = new Student()
            {
                StudentNumber = student1.StudentNumber,
                FullName = student1.FullName,
                EmailAddress = student1.EmailAddress,
                PhoneNumber = student1.PhoneNumber

            };

            List<Subject> Subjectss = new List<Subject>();

            foreach (Subject subject in student1.Subjects)
            {
                Subject subject1 = new Subject()
                {
                    Name = subject.Name,
                    Credits = subject.Credits,
                    Semestar = subject.Semestar,
                    StudentId = subject.StudentId
                };
                Subjectss.Add(subject1);
            }
            student.Subjects = Subjectss;
            _studentRepository.Insert(student);

        }
    }
}
