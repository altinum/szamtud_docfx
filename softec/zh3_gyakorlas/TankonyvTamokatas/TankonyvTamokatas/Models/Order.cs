using System;
using System.Collections.Generic;

namespace TankonyvTamokatas.Models;

public partial class Order
{
    public int OrderSk { get; set; }

    public int? StudentFk { get; set; }

    public int? TextbookFk { get; set; }

    public virtual Student? StudentFkNavigation { get; set; }

    public virtual Textbook? TextbookFkNavigation { get; set; }
}
