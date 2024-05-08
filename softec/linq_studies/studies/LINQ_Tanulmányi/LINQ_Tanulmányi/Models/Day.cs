using System;
using System.Collections.Generic;

namespace LINQ_Tanulmányi.Models;

public partial class Day
{
    public byte DayId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
}
