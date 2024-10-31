using System.ComponentModel.DataAnnotations;

public class HtmlElementType {
    [Key]
    public int TypeId { get; set; }

    public string TypeName { get; set; }
}