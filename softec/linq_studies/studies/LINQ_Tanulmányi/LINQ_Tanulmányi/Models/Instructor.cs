using System;
using System.Collections.Generic;

namespace LINQ_Tanulmányi.Models;

public partial class Instructor
{
    public int InstructorSk { get; set; }

    public string? Salutation { get; set; }

    public string Name { get; set; } = null!;

    public byte? StatusFk { get; set; }

    public string? EmployementFk { get; set; }

    public virtual Employement? EmployementFkNavigation { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual Status? StatusFkNavigation { get; set; }
}
