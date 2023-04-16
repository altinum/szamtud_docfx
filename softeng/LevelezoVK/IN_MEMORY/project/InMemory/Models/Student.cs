using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemory.Models
{
    public class Student
    {
        public string Neptun { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; }

        public decimal? AverageGrade { get; set; }
        public bool? IsActive { get; set; }
    }
}
