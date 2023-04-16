using System;
using System.Collections.Generic;

namespace RemoteDBTest.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Neptun { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public decimal? AverageGrade { get; set; }

    public bool IsActive { get; set; }
}
