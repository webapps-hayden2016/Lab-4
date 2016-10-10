using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_4.Models
{
    public class Person
    {
        public Person() { }
        public Person(String first, String last, DateTime birth, int inAge)
        {
            FirstName = first;
            LastName = last;
            BirthDate = birth;
            Age = inAge;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
    }
}
