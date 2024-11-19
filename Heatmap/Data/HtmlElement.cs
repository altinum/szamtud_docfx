using System.ComponentModel.DataAnnotations;

namespace Heatmap.Data;

public class HtmlElement {
    [Key]
    public int ElementId { get; set; }

    public string Element { get; set; }
}