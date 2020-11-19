using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.DataModels
{
   public class Subject
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public int Semestar { get; set; }
        public Student Student1 { get; set; }

        public int StudentId { get; set; }
    }
}
