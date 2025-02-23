using System;
using System.Collections.Generic;

namespace TankonyvTamokatas.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Name { get; set; }

    public string? Neptun { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
