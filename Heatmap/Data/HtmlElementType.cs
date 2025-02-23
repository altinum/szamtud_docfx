using System.ComponentModel.DataAnnotations;

namespace Heatmap.Data;

public class HtmlElementType {
    [Key]
    public int TypeId { get; set; }

    public string TypeName { get; set; }
}