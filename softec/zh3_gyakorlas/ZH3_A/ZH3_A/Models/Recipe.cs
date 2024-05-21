using System;
using System.Collections.Generic;

namespace ZH3_A.Models;

public partial class Recipe
{
    public int RecipeSk { get; set; }

    public int? CocktailFk { get; set; }

    public short? MaterialFk { get; set; }

    public decimal Quantity { get; set; }

    public virtual Cocktail? CocktailFkNavigation { get; set; }

    public virtual Material? MaterialFkNavigation { get; set; }
}
