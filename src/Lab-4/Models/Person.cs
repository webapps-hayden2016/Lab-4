using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Enter a first name!")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Must be between {2} and {1} characters long!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter a last name too!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Also set your date of birth!")]
        public DateTime BirthDate { get; set; }

        public int Age { get; set; }
    }
}
