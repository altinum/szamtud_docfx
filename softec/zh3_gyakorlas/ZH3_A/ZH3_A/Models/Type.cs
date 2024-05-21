using System;
using System.Collections.Generic;

namespace ZH3_A.Models;

public partial class Type
{
    public byte TypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Cocktail> Cocktails { get; set; } = new List<Cocktail>();
}
